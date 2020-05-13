using System;
using AutoMapper;
using Payments.Application.Queries.AppSettingQueries;
using Payments.Application.Queries.PaymentMethodQueries;
using Payments.Application.Queries.ProviderQueries;
using Payments.Application.Queries.TransactionQueries;

namespace Payments.Application.Queries.Mapping
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            AppSettingMappingConfiguration.Configure(cfg);
            TransactionMappingConfiguration.Configure(cfg);
            PaymentMethodMappingConfiguration.Configure(cfg);
            ProviderMappingConfiguration.Configure(cfg);
        }
    }
}
