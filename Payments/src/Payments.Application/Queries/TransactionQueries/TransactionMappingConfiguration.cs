using System;
using AutoMapper;
using Payments.Domain.Entities;
using Payments.Domain.Paging;

namespace Payments.Application.Queries.TransactionQueries
{
    public static class TransactionMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Transaction, TransactionViewModel>();
            cfg.CreateMap<Transaction, TransactionListViewModel>();
            cfg.CreateMap<PagedResult<Transaction>, PagedViewModelResult<TransactionListViewModel>>();
        }
    }
}
