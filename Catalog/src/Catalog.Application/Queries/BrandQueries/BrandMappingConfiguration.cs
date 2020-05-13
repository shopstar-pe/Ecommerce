using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.BrandQueries
{
    public static class BrandMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Brand, BrandViewModel>();
            cfg.CreateMap<Brand, BrandListViewModel>();
            cfg.CreateMap<PagedResult<Brand>, PagedViewModelResult<BrandListViewModel>>();
        }
    }
}
