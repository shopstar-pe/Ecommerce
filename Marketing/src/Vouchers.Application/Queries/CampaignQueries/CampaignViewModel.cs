using System;
using System.Collections.Generic;
using Vouchers.Domain.Entities;

namespace Vouchers.Application.Queries.CampaignQueries
{

    public class CampaignListViewModel : CampaignViewModel
    {
        
    }

    public class CampaignViewModel
    {
        public int CampaignId { get; set; }
        public string TenantId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CampaignStatus CampaignStatus { get; set; }

        public int? SellerId { get; set; }

        public bool Enabled
        {
            get
            {
                if (this.CampaignStatus == CampaignStatus.Inactive)
                    return false;

                return true;
            }
        }
    }

}
