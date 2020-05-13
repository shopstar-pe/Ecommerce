using System;
using AutoMapper;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Paging;

namespace Vouchers.Application.Queries.CouponQueries
{
    public static class CouponMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Coupon, CouponViewModel>();
            cfg.CreateMap<Coupon, CouponListViewModel>();
            cfg.CreateMap<PagedResult<Coupon>, PagedViewModelResult<CouponListViewModel>>();
        }
    }
}
