using System;
namespace Catalog.Application.Commands.MealCommand.Models
{
    public class MealVariationModel
    {
        public int SkuId { get; set; }
        public string VariantName { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? SpecialPrice { get; set; }
        public int Stock { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
    }
}
