using System;
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CheckOut.Application.Behaviors;
using CheckOut.Application.Queries.Mapping;

namespace CheckOut.Application
{
    public static class DependencyInjection
    {
        public static void AddCheckOutApplicationServices(this IServiceCollection services)
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
