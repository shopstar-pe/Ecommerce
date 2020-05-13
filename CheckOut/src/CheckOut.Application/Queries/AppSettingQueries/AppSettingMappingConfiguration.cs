using System;
using AutoMapper;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Paging;

namespace CheckOut.Application.Queries.AppSettingQueries
{
    public static class AppSettingMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AppSetting, AppSettingViewModel>();
            cfg.CreateMap<AppSetting, AppSettingListViewModel>();
            cfg.CreateMap<PagedResult<AppSetting>, PagedViewModelResult<AppSettingPaginationViewModel>>();
        }
    }
}
