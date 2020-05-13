using System;
using AutoMapper;
using Sales.Application.Queries.AppSettingQueries;
using Sales.Application.Queries.ClientQueries;
using Sales.Application.Queries.SaleOrderQueries;

namespace Sales.Application.Queries.Mapping
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            AppSettingMappingConfiguration.Configure(cfg);
            ClientMappingConfiguration.Configure(cfg);
            SaleOrderMappingConfiguration.Configure(cfg);
        }
    }
}
