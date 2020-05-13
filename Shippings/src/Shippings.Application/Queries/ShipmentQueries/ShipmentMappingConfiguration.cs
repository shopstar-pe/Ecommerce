using System;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.ShipmentQueries
{
    public static class ShipmentMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Shipment, ShipmentViewModel>();
            cfg.CreateMap<Shipment, ShipmentListViewModel>();
            cfg.CreateMap<PagedResult<Shipment>, PagedViewModelResult<ShipmentListViewModel>>();
        }
    }
}
