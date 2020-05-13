using System;
using System.Collections.Generic;
using Payments.Domain.Entities;

namespace Payments.Application.Queries.TransactionQueries
{
    
    public class TransactionListViewModel : TransactionViewModel
    {
        
    }

    public class TransactionViewModel
    {
        public string TenantId { get; set; }

        public Guid TransactionId { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string OrderGroup { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Email { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string CountryIsoCode { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public TransactionStatusType TransactionStatusType { get; set; }
        public string Content { get; set; }

        public int? SellerId { get; set; }
        public string SellerName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }

        public string PlaceHolder { get; set; }
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Cvv { get; set; }

        public string CardType { get; set; }

        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
    }

}
