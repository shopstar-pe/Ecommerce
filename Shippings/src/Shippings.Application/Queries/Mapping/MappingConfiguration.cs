using System;
using AutoMapper;
using Shippings.Application.Queries.AppSettingQueries;
using Shippings.Application.Queries.BranchQueries;
using Shippings.Application.Queries.CourierQueries;
using Shippings.Application.Queries.DriverQueries;
using Shippings.Application.Queries.ShipmentQueries;
using Shippings.Application.Queries.ShippingMethodQueries;

namespace Shippings.Application.Queries.Mapping
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            AppSettingMappingConfiguration.Configure(cfg);
            ShipmentMappingConfiguration.Configure(cfg);
            ShippingMethodMappingConfiguration.Configure(cfg);
            CourierMappingConfiguration.Configure(cfg);
            DriverMappingConfiguration.Configure(cfg);
            BranchMappingConfiguration.Configure(cfg);
        }
    }
}
