using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.AppSettingQueries
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
