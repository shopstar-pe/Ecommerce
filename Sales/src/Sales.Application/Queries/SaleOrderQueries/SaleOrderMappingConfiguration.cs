using System;
using AutoMapper;
using Sales.Domain.Entities;
using Sales.Domain.Paging;

namespace Sales.Application.Queries.SaleOrderQueries
{
    public static class SaleOrderMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<SaleOrder, SaleOrderViewModel>();
            cfg.CreateMap<SaleOrder, SaleOrderListViewModel>();
            cfg.CreateMap<SaleOrderItem, SaleOrderItemListViewModel>();
            cfg.CreateMap<SaleOrderItemService, SaleOrderItemService>();
            cfg.CreateMap<SaleOrderTracking, SaleOrderTrackingListViewModel>();
            cfg.CreateMap<PagedResult<SaleOrder>, PagedViewModelResult<SaleOrderListViewModel>>();
        }
    }
}
