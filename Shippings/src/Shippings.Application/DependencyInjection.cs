using System;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shippings.Application.Behaviors;
using Shippings.Application.Queries.Mapping;

namespace Shippings.Application
{
    public static class DependencyInjection
    {
        public static void AddShippingApplicationServices(this IServiceCollection services)
        {
            // MediatR Handlers Registry
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            // Automapper Registry
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                MappingConfiguration.ConfigureMappers(cfg);
            });

            IMapper mapper = mapperCfg.CreateMapper();
            services.AddSingleton(mapper);


        }

    }
}
