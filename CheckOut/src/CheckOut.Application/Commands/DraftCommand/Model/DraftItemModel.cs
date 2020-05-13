using System;
using System.Collections.Generic;

namespace CheckOut.Application.Commands.DraftCommand.Model
{
    public class DraftItemModel
    {
        public string DraftItemId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public string AdditionalNote { get; set; }

        public List<DraftItemVariantModel> Variants { get; set; }
        public List<DraftItemComplementModel> Complements { get; set; }
    }

    public class DraftItemVariantModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
    }

    public class DraftItemComplementModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public decimal SpecialPrice { get; set; }
    }

}
