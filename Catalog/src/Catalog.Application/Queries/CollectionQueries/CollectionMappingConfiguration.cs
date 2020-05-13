using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.CollectionQueries
{
    public static class CollectionMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Collection, CollectionViewModel>();
            cfg.CreateMap<Collection, CollectionListViewModel>();
            cfg.CreateMap<PagedResult<Collection>, PagedViewModelResult<CollectionListViewModel>>();
        }
    }
}
