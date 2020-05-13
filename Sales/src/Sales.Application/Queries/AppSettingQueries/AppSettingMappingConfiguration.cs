using System;
using AutoMapper;
using Sales.Domain.Entities;
using Sales.Domain.Paging;

namespace Sales.Application.Queries.AppSettingQueries
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
