using System;
using System.Collections.Generic;

namespace Sales.Application.Commands.SaleOrderCommand.Models
{
    public class SaleOrderItemModel
    {
        public int SellerId { get; set; }
        public string SellerName { get; set; }
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
        public string AdditionalNote { get; set; }
        public decimal Tax { get; set; }
        public List<SaleOrderServiceItemModel> Services { get; set; }
    }

    public class SaleOrderServiceItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
    }
}
