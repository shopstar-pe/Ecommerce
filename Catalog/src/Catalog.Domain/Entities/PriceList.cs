
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Domain.Entities
{
    public class PriceList : BaseEntity
    {

        public PriceList()
        {

        }

        public int PriceListId { get; set; }
        public int ProductId { get; set; }
        public string ReferenceId { get; set; }

        /// <summary>
        /// Category Type
        /// </summary>
        public string Category { get; set; }

        public decimal Price { get; set; }

        public virtual Product Product { get; set; }

    }
}
