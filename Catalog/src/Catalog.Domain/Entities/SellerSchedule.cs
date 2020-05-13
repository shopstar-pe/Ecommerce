using System;
namespace Catalog.Domain.Entities
{
    public class SellerSchedule : BaseEntity
    {
        public int SellerScheduleId { get; set; }

        public int OpenInMinute { get; set; }
        public int CloseInMinute { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
    }
}
