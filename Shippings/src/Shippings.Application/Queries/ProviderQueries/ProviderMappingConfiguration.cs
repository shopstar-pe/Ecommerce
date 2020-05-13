using System;
using System.Collections.Generic;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.ProviderQueries
{
    public static class ProviderMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Provider, ProviderViewModel>();
            cfg.CreateMap<Provider, ProviderListViewModel>();
            cfg.CreateMap<List<Provider>, List<ProviderListViewModel>>();

            cfg.CreateMap<ProviderSetting, ProviderSettingViewModel>();
            cfg.CreateMap<List<ProviderSetting>, List<ProviderSettingViewModel>>();

        }
    }
}
