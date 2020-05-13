using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.AdditionalServiceQueries
{
    public static class AdditionalServiceMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AdditionalService, AdditionalServiceViewModel>();
            cfg.CreateMap<AdditionalService, AdditionalServiceListViewModel>();
            cfg.CreateMap<AdditionalServicePrice, AdditionalServicePriceViewModel>();
            cfg.CreateMap<PagedResult<AdditionalService>, PagedViewModelResult<AdditionalServiceListViewModel>>();
        }
    }
}
