using System;
using System.Collections.Generic;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.DriverQueries
{
    public static class DriverMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Driver, DriverViewModel>();
            cfg.CreateMap<Driver, DriverListViewModel>();
            cfg.CreateMap<PagedResult<Driver>, PagedViewModelResult<DriverListViewModel>>();
        }
    }
}
