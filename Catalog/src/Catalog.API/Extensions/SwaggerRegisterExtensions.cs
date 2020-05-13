using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Catalog.API.Extensions
{
    public static class SwaggerRegisterExtensions
    {

        public static void AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(configuration["Swagger:Version"], new OpenApiInfo
                {
                    Version = configuration["Swagger:Version"],
                    Title = configuration["Swagger:Title"],
                    Description = configuration["Swagger:Description"],
                    Contact = new OpenApiContact
                    {
                        Name = configuration["Swagger:ContactName"],
                        Email = configuration["Swagger:ContactEmail"],
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                    }
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

        }

        public static void UseCustomSwagger(this IApplicationBuilder app, IConfiguration configuration)
        {

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(configuration["Swagger:Endpoint"], $"{configuration["Swagger:Title"]} {configuration["Swagger:Version"]}");
                c.RoutePrefix = string.Empty;
            });

        }

    }
}
