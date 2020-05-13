using System;
using System.Collections.Generic;
using AutoMapper;
using Shippings.Domain.Entities;
using Shippings.Domain.Paging;

namespace Shippings.Application.Queries.BranchQueries
{
    public static class BranchMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Branch, BranchViewModel>();
            cfg.CreateMap<Branch, BranchListViewModel>();
            cfg.CreateMap<PagedResult<Branch>, PagedViewModelResult<BranchListViewModel>>();
        }
    }
}
