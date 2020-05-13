using System;
using System.Linq;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.CollectionGroupQueries
{
    public static class CollectionGroupMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CollectionGroup, CollectionGroupViewModel>();
            cfg.CreateMap<CollectionGroup, CollectionGroupListViewModel>();
            cfg.CreateMap<Collection, CollectionItemListViewModel>()
                    .ForMember(dest => dest.Products, src => src.MapFrom(s => s.ProductCollections.Select(x=> x.Product)));

            cfg.CreateMap<PagedResult<CollectionGroup>, PagedViewModelResult<CollectionGroupListViewModel>>();
        }
    }
}
