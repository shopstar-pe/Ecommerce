using System;
namespace Vouchers.Domain.Entities
{
    public enum ConditionType
    {
        Percent,
        Amount,
        FreeShipping
    }

    public enum CouponStatus
    {
        Active,
        Inactive
    }

    public enum CampaignStatus
    {
        Active,
        Inactive
    }

}
