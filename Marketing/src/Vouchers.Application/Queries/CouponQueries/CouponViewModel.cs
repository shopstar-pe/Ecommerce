using System;
using System.Collections.Generic;
using Vouchers.Domain.Entities;

namespace Vouchers.Application.Queries.CouponQueries
{
   
    public class CouponListViewModel : CouponViewModel
    {
       
    }

    public class CouponViewModel
    {
        public string TenantId { get; set; }
        public int CouponId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UtmSource { get; set; }
        public string UtmCampaign { get; set; }

        public ConditionType ConditionType { get; set; }
        public CouponStatus CouponStatus { get; set; }
        /// <summary>
        /// Value discount ( percent, amount )
        /// </summary>
        public decimal Value { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsUnlimited { get; set; }
        public int UsageLimit { get; set; }
        public bool LimitByCustomer { get; set; }
        public int Used { get; set; }
        public decimal? MinOrderAmount { get; set; }
        public decimal? MaxOrderAmount { get; set; }

        public int? SellerId { get; set; }

        public bool Enabled
        {
            get
            {
                if (this.CouponStatus == CouponStatus.Inactive)
                    return false;

                return true;
            }
        }
    }

}
