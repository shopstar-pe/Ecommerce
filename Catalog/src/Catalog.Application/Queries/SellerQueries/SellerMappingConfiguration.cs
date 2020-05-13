using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.SellerQueries
{
    public static class SellerMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Seller, SellerViewModel>();
            cfg.CreateMap<Seller, SellerListViewModel>();
            cfg.CreateMap<PagedResult<Seller>, PagedViewModelResult<SellerListViewModel>>();
        }
    }
}
