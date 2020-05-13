using System;
using System.Collections.Generic;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.ShippingMethodQueries
{
    public static class ShippingMethodMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<ShippingMethod, ShippingMethodViewModel>();
            cfg.CreateMap<ShippingMethod, ShippingMethodListViewModel>();
            cfg.CreateMap<PagedResult<ShippingMethod>, PagedViewModelResult<ShippingMethodListViewModel>>();
        }
    }
}
