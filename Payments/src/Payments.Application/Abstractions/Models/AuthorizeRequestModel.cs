using System;
using System.Collections.Generic;

namespace Payments.Application.Abstractions.Models
{
    public class AuthorizeRequestModel
    {
        public Guid TransactionId { get; set; }
        public string OrderNumber { get; set; }
        public string Email { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string PlaceHolder { get; set; }
        public string Cvv { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public string CurrencyIsoCode { get; set; }
        public Dictionary<string, string> Settings { get; set; }
    }
}
