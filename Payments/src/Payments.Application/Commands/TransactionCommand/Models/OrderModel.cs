using System;
using System.ComponentModel.DataAnnotations;

namespace Payments.Application.Commands.TransactionCommand.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderGroup { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public int? SellerId { get; set; }
        public string SellerName { get; set; }
    }
}
