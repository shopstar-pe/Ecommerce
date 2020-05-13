using System;
using AutoMapper;
using Vouchers.Application.Queries.AppSettingQueries;
using Vouchers.Application.Queries.CampaignQueries;
using Vouchers.Application.Queries.CouponQueries;

namespace Vouchers.Application.Queries.Mapping
{
    public static class MappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            AppSettingMappingConfiguration.Configure(cfg);
            CampaignMappingConfiguration.Configure(cfg);
            CouponMappingConfiguration.Configure(cfg);
        }
    }
}
