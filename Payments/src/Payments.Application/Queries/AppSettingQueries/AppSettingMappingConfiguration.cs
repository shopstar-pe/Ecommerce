using System;
using AutoMapper;
using Payments.Domain.Entities;
using Payments.Domain.Paging;

namespace Payments.Application.Queries.AppSettingQueries
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
