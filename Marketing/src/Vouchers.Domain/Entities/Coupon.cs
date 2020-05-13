using System;
namespace Vouchers.Domain.Entities
{
    public class Coupon : BaseEntity, IAggregateRoot
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

        public void SetDates(DateTime? startDate, DateTime? endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public void SetMinMaxOrderValue(decimal? min, decimal? max)
        {
            this.MinOrderAmount = min;
            this.MaxOrderAmount = max;
        }

        public static class Factory
        {
            public static Coupon Create(string tenantId, int? sellerId, string code, string name, string description, ConditionType type, decimal value, string createdBy)
            {
                var entity = new Coupon
                {
                    TenantId = tenantId,
                    SellerId = sellerId,
                    Code = code,
                    Name = name,
                    Description = description ?? name,
                    Value = value,
                    ConditionType = type,
                    CouponStatus = CouponStatus.Active,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }


    }

}
