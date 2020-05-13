using System;
using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Application.Queries.LocationQueries
{
    public static class LocationMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Location, LocationViewModel>();
            cfg.CreateMap<Location, LocationListViewModel>();
            cfg.CreateMap<PagedResult<Location>, PagedViewModelResult<LocationListViewModel>>();
        }
    }
}
