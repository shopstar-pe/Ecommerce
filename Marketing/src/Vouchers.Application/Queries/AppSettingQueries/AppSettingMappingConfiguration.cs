using System;
using AutoMapper;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Paging;

namespace Vouchers.Application.Queries.AppSettingQueries
{
    public static class AppSettingMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AppSetting, AppSettingViewModel>();
            cfg.CreateMap<AppSetting, AppSettingListViewModel>();
            cfg.CreateMap<PagedResult<AppSetting>, PagedViewModelResult<AppSettingViewModel>>();
        }
    }
}
