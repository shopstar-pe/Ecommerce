using System;
using AutoMapper;
using CheckOut.Application.Queries.AppSettingQueries;
using CheckOut.Application.Queries.DraftQueries;

namespace CheckOut.Application.Queries.Mapping
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            AppSettingMappingConfiguration.Configure(cfg);
            DraftMappingConfiguration.Configure(cfg);
        }
    }
}
