using System;
using System.Collections.Generic;


namespace Sales.Domain.Entities
{
    public class SaleOrderItem : BaseEntity
    {
        public SaleOrderItem() : base()
        {
        }

        public int SaleOrderItemId { get; set; }
        public int SaleOrderId { get; set; }
        public virtual SaleOrder SaleOrder { get; set; }
        public SaleOrderItemStatus SaleOrderItemStatus { get; set; }

        public string ProductId { get; set; }
        public string SkuId { get; set; }
        public string SKU { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string AdditionalNote { get; set; }

        public virtual ICollection<SaleOrderItemService> Services { get; set; }

        public void AddService(string name, decimal basePrice, decimal specialPrice) {
            if (this.Services == null)
                this.Services = new List<SaleOrderItemService>();

            this.Services.Add(new SaleOrderItemService {
                Name = name,
                BasePrice = basePrice,
                SpecialPrice = specialPrice,
            });
        }
    }
}
