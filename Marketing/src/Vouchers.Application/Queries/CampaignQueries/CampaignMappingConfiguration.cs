using System;
using AutoMapper;
using Vouchers.Domain.Entities;
using Vouchers.Domain.Paging;

namespace Vouchers.Application.Queries.CampaignQueries
{
    public static class CampaignMappingConfiguration
    {
        public static void Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Campaign, CampaignViewModel>();
            cfg.CreateMap<Campaign, CampaignListViewModel>();
            cfg.CreateMap<PagedResult<Campaign>, PagedViewModelResult<CampaignListViewModel>>();
        }
    }
}
