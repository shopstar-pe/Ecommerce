using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Catalog.Application;
using Catalog.Infrastructure;
using Catalog.Persistence;

using CheckOut.Application;
using CheckOut.Infrastructure;
using CheckOut.Persistence;

using Vouchers.Application;
using Vouchers.Infrastructure;
using Vouchers.Persistence;

using Payments.Application;
using Payments.Infrastructure;
using Payments.Persistence;

using Shippings.Application;
using Shippings.Infrastructure;
using Shippings.Persistence;

using Sales.Application;
using Sales.Infrastructure;
using Sales.Persistence;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using Ocelot.Middleware;
using Ocelot.DependencyInjection;
using Search.API.Services;
using Search.API;
using Ecommerce.API.Services;
using Ecommerce.API.Proxy;
using Payments.Integration;

namespace Ecommerce.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var catalogAssembly = typeof(Catalog.API.Controllers.AppSettingsController).Assembly;
            var checkOutAssembly = typeof(CheckOut.API.Controllers.AppSettingsController).Assembly;
            var voucherAssembly = typeof(Vouchers.API.Controllers.AppSettingsController).Assembly;
            var paymentAssembly = typeof(Payments.API.Controllers.AppSettingsController).Assembly;
            var shippingAssembly = typeof(Shippings.API.Controllers.AppSettingsController).Assembly;
            var saleAssembly = typeof(Sales.API.Controllers.AppSettingsController).Assembly;
            var searchAssembly = typeof(Search.API.Controllers.SearchController).Assembly;

            var authority = Configuration["Authority:Url"];

            services.AddCors();
            services.AddAuthentication(options => {
                options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
            })
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = authority;
                    options.RequireHttpsMetadata = false;

                    options.NameClaimType = "name";
                    options.RoleClaimType = "role";
                });

            var builder = services.AddControllers();

            builder.AddApplicationPart(catalogAssembly);
            builder.AddApplicationPart(checkOutAssembly);
            builder.AddApplicationPart(voucherAssembly);
            builder.AddApplicationPart(paymentAssembly);
            builder.AddApplicationPart(shippingAssembly);
            builder.AddApplicationPart(saleAssembly);
            builder.AddApplicationPart(searchAssembly);

            builder.AddControllersAsServices();

            services.AddOcelot();

            // Add API Versioning to the service container to your project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version
                config.DefaultApiVersion = new ApiVersion(1, 0);
                // If the client hasn't specified the API version in the request, use the default API version number 
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });

            services.AddAuthorization(options =>
            {
                var authorizationPolicy = new AuthorizationPolicyBuilder(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();

                options.AddPolicy("RequireAuthenticatedUser", authorizationPolicy);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["Swagger:Version"], new OpenApiInfo
                {
                    Version = Configuration["Swagger:Version"],
                    Title = Configuration["Swagger:Title"],
                    Description = Configuration["Swagger:Description"],
                    Contact = new OpenApiContact
                    {
                        Name = Configuration["Swagger:ContactName"],
                        Email = Configuration["Swagger:ContactEmail"],
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                    }
                });

                c.CustomSchemaIds(x => x.FullName);

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            // ASP.NET HttpContext dependency
            services.AddHttpContextAccessor();

            services.AddCatalogApplicationServices();
            services.AddCatalogRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddCatalogInfrastructureServices(Configuration.GetConnectionString("QueueStorageConnection"));

            services.AddCheckOutApplicationServices();
            services.AddCheckOutRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddCheckOutInfrastructureServices();

            services.AddVoucherApplicationServices();
            services.AddVoucherRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddVoucherInfrastructureServices();

            services.AddPaymentApplicationServices();
            services.AddPaymentRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddPaymentInfrastructureServices();
            services.AddPaymentIntegrationServices();

            services.AddSaleApplicationServices();
            services.AddSaleRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddSaleInfrastructureServices();

            services.AddShippingApplicationServices();
            services.AddShippingRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddShippingInfrastructureServices();

            services.AddSearchRepositories(Configuration.GetConnectionString("DefaultConnection"));
            services.AddSearchApplicationServices();

            // Automapper Registry
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                Catalog.Application.Queries.Mapping.MappingConfiguration.ConfigureMappers(cfg);
                Sales.Application.Queries.Mapping.MappingConfiguration.ConfigureMappers(cfg);
                CheckOut.Application.Queries.Mapping.MappingConfiguration.ConfigureMappers(cfg);
                Vouchers.Application.Queries.Mapping.MappingConfiguration.ConfigureMappers(cfg);
                Payments.Application.Queries.Mapping.MappingConfiguration.ConfigureMappers(cfg);
                Shippings.Application.Queries.Mapping.MappingConfiguration.ConfigureMappers(cfg);
                // Rest Mapping
                RestMappingConfiguration.ConfigureMappers(cfg);
            });

            IMapper mapper = mapperCfg.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IPlaceOrderService, PlaceOrderService>();
            services.AddTransient<ICheckOutProxyService, CheckOutProxyService>();
            services.AddTransient<IOrderProxyService, OrderProxyService>();
            services.AddTransient<IShippingProxyService, ShippingProxyService>();
            services.AddTransient<IPaymentProxyService, PaymentProxyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod());
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration["Swagger:Endpoint"], $"{Configuration["Swagger:Title"]} {Configuration["Swagger:Version"]}");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            await app.UseOcelot();
        }
    }
}
