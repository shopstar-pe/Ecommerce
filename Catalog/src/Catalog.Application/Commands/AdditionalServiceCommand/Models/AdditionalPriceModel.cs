using System;
using System.ComponentModel.DataAnnotations;
using Catalog.Domain.Entities;

namespace Catalog.Application.Commands.AdditionalServiceCommand.Models
{
    public class AdditionalPriceModel
    {
        public int PriceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public AdditionalServicePriceStatus Status { get; set; }
    }
}
