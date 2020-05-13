using System;
using System.Collections.Generic;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.CourierQueries
{
    public static class CourierMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Courier, CourierViewModel>();
            cfg.CreateMap<Courier, CourierListViewModel>();
            cfg.CreateMap<PagedResult<Courier>, PagedViewModelResult<CourierListViewModel>>();
        }
    }
}
