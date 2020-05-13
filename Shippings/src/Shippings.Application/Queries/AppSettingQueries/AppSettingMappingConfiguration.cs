using System;
using System.Collections.Generic;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.AppSettingQueries
{
    public static class AppSettingMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AppSetting, AppSettingViewModel>();
            cfg.CreateMap<AppSetting, AppSettingListViewModel>();
            cfg.CreateMap<PagedResult<AppSetting>, PagedViewModelResult<AppSettingListViewModel>>();
        }
    }
}
