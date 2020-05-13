using System;
using AutoMapper;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Paging;

namespace CheckOut.Application.Queries.DraftQueries
{
    public static class DraftMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Draft, DraftViewModel>();
            cfg.CreateMap<Draft, DraftListViewModel>();

            cfg.CreateMap<DraftItem, DraftItemViewList>();
            cfg.CreateMap<DraftItemVariant, DraftItemVariantViewList>();
            cfg.CreateMap<DraftItemService, DraftItemComplementViewList>();

            cfg.CreateMap<PagedResult<Draft>, PagedViewModelResult<DraftListViewModel>>();

           
        }
    }
}
