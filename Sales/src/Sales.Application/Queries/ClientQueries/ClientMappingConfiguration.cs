using System;
using AutoMapper;
using Sales.Domain.Entities;
using Sales.Domain.Paging;

namespace Sales.Application.Queries.ClientQueries
{
    public static class ClientMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Client, ClientViewModel>();
            cfg.CreateMap<Client, ClientListViewModel>();
            cfg.CreateMap<PagedResult<Client>, PagedViewModelResult<ClientListViewModel>>();
        }
    }
}
