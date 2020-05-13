using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Sales.Domain.Entities
{
    public class Client : BaseEntity
    {
        public Client() : base()
        {
        }

        public string TenantId { get; set; }

        public int ClientId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string EntityName { get; set; }

        public virtual List<SaleOrder> SaleOrders { get; set; }
        public virtual List<ClientSeller> ClientSellers { get; set; }

        public void AssociateToSeller(int sellerId)
        {
            if (this.ClientSellers == null)
                this.ClientSellers = new List<ClientSeller>();

            if (this.ClientSellers.Any(c => c.SellerId.Equals(sellerId)))
                return;

            this.ClientSellers.Add(new ClientSeller { SellerId = sellerId });
        }

        public SaleOrder CreateOrder(string tenantId, int orderType, int sellerId, string sellerName, string source, string orderGroup, string countryISO, string currencyISO, string couponCode) {
            if (this.SaleOrders == null)
                this.SaleOrders = new List<SaleOrder>();

            var order = SaleOrder.Factory.Create(tenantId, orderType, this.ClientId, sellerId, sellerName, source, orderGroup, countryISO, currencyISO, couponCode, this.CreatedBy);

            this.SaleOrders.Add(order);

            return order;
        }

        public static class Factory {

            public static Client Create( string tenantId, string email, string firstName, string lastName, string phone, string identificationNumber, string identificationType, string entityName, string createdBy) {
                var entity = new Client {
                    TenantId = tenantId,
                    Email = email,
                    FirstName = firstName,
                    LastName = lastName,
                    Phone = phone,
                    IdentificationNumber = identificationNumber,
                    IdentificationType = identificationType,
                    EntityName = entityName,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }
    }
}
