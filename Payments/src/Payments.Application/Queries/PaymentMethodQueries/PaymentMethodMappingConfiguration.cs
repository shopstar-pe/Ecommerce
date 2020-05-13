using System;
using System.Collections.Generic;
using AutoMapper;
using Payments.Domain.Entities;
using Payments.Domain.Paging;

namespace Payments.Application.Queries.PaymentMethodQueries
{
    public static class PaymentMethodMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PaymentMethod, PaymentMethodViewModel>();
            cfg.CreateMap<PaymentMethod, PaymentMethodListViewModel>();
            cfg.CreateMap<List<PaymentMethod>, List<PaymentMethodListViewModel>>();
        }
    }
}
