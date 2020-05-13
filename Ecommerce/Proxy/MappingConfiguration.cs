using System;
using AutoMapper;
using CheckOut.Application.Queries.DraftQueries;
using Ecommerce.API.Proxy.Models;
using Sales.Application.Commands.SaleOrderCommand;
using Sales.Application.Commands.SaleOrderCommand.Models;
using Sales.Application.Queries.ClientQueries;
using Sales.Application.Queries.SaleOrderQueries;
using Sales.Domain.Entities;

namespace Ecommerce.API.Proxy
{
    public static class RestMappingConfiguration
    {
        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<DraftViewModel, CheckOutModel>();
            cfg.CreateMap<DraftItemViewList, CheckOutItemModel>();


            cfg.CreateMap<ClientViewModel, ClientResponseModel>();
            cfg.CreateMap<SaleOrderItemListViewModel, OrderItemResponseModel>();
            cfg.CreateMap<SaleOrderViewModel, OrderResponseModel>();
            

            cfg.CreateMap<ClienRequestModel, ClientModel>();
            cfg.CreateMap<ShippingAddressRequestModel, ShippingAddressModel>();
            cfg.CreateMap<SaleOrderItemRequestModel, SaleOrderItemModel>();
            cfg.CreateMap<OrderRequestModel, CreateSaleOrderCommand>();
        }
    }
}