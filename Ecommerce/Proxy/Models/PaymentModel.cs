using System;
namespace Ecommerce.API.Proxy.Models
{
    public class AuthorizeRequestModel
    {
        public string TransactionId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string CountryIsoCode { get; set; }
        public string CurrencyIsoCode { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderGroup { get; set; }
        public string ReferenceDescription { get; set; }
        public string Placeholder { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Cvv { get; set; }
        public decimal Amount { get; set; }
        public int Installments { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
    }

    public class AuthorizeResponseModel
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; }
    }
}
