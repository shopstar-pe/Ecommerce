using System;
using System.ComponentModel.DataAnnotations;

namespace Payments.Domain.Entities
{
    public class Transaction : BaseEntity, IAggregateRoot
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
        public virtual Provider Provider { get; set; }

        public string TransactionExternalId { get; set; }
        public string TransactionExternalToken { get; set; }
        public string TransactionExternalAuthCode { get; set; }


        [Timestamp]
        public byte[] RowVersion { get; set; }

        public void Authorize(string token,
            string authCode,
            string transactionId,
            DateTime transactionDate,
            string cardType, string placeHolder, string cardNumber, string month, string year)
        {
            this.TransactionExternalToken = token;
            this.TransactionExternalAuthCode = authCode;
            this.TransactionExternalId = transactionId;
            this.TransactionDate = transactionDate;
            this.TransactionStatusType = TransactionStatusType.Authorized;
            this.UpdatedOn = DateTime.UtcNow;
            this.PlaceHolder = placeHolder;
            this.CardNumber = cardNumber;
            this.Month = month;
            this.Year = year;
            this.CardType = cardType;
        }

        public void Capture()
        {
            this.TransactionStatusType = TransactionStatusType.Captured;
            this.UpdatedOn = DateTime.UtcNow;
        }

        public void Cancel()
        {
            this.TransactionStatusType = TransactionStatusType.Cancelled;
            this.UpdatedOn = DateTime.UtcNow;
        }

        public static class Factory
        {
            public static Transaction Create(string tenantId,
                int providerId,
                int? sellerId,
                string sellerName,
                Guid transactionId,
                int orderId,
                string orderGroup,
                string orderNumber,
                decimal amount,
                string description,
                string email,
                string firstName,
                string lastName,
                string identificationType,
                string identificationNumber,
                string currencyIsoCode, string countryIsoCode,
                string createdBy)
            {
                var entity = new Transaction()
                {
                    TenantId = tenantId,
                    SellerId = sellerId,
                    SellerName = sellerName,
                    FirstName = firstName,
                    LastName = lastName,
                    IdentificationType = identificationType,
                    IdentificationNumber = identificationNumber,
                    TransactionId = transactionId,
                    ProviderId = providerId,
                    OrderId = orderId,
                    OrderGroup = orderGroup,
                    OrderNumber = orderNumber,
                    Email = email,
                    CurrencyIsoCode = currencyIsoCode,
                    CountryIsoCode = countryIsoCode,
                    Amount = amount,
                    Description = description,
                    TransactionStatusType = TransactionStatusType.Pending,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }
}
