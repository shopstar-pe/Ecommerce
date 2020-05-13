using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models
{
    public class PlaceOrderModel
    {
        public string CheckOutId { get; set; }
        public int SellerId { get; set; }
        public string Source { get; set; }
        public string OrderType { get; set; }

        public string CurrencyIsoCode { get; set; }
        public string CountryIsoCode { get; set; }

        [Required]
        public PlaceOrderContactModel Contact { get; set; }
        [Required]
        public PlaceOrderShippingModel Shipping { get; set; }
        [Required]
        public PlaceOrderPaymentModel Payment { get; set; }
    }

    public class PlaceOrderPaymentModel
    {
        [Required]
        public string PaymentMethodGroupId { get; set; }
        [Required]
        public string PaymentMethodGroupName { get; set; }
        [Required]
        public string PaymentMethodId { get; set; }
        [Required]
        public string PaymentMethodName { get; set; }

        public PlaceOrderPaymentCardModel Card { get; set; }
    }

    public class PlaceOrderPaymentCardModel
    {
        public string Placeholder { get; set; }
        public string CardNumber { get; set; }
        public string CardType { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Cvv { get; set; }
        public int Installments { get; set; }
    }

    public class PlaceOrderContactModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string Phone { get; set; }
    }

    public class PlaceOrderShippingModel
    {
        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }
        public string AddressNumber { get; set; }
        public string Reference { get; set; }
        public string PostalCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public PlaceOrderReceptorModel Receptor { get; set; }
    }

    public class PlaceOrderReceptorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string Phone { get; set; }
    }

    public class OrderResultModel
    {
        public int OrderId { get; set; }
        public string OrderGroup { get; set; }
        public string OrderNumber { get; set; }
    }
}
