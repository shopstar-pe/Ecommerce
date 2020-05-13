using System;
using System.Collections.Generic;

namespace Shippings.Domain.Entities
{
    public class Courier : BaseEntity
    {
        public string TenantId { get; set; }

        public int CourierId { get; set; }
        public string Name { get; set; }

        public int SellerId { get; set; }
        public string SellerName { get; set; }

        public string ExternalId { get; set; }
        public string ExternalName { get; set; }

        public string ClientId { get; set; }
        public string ClientCredentials { get; set; }

        public virtual List<Branch> Branches { get; set; }
        public virtual List<Driver> Drivers { get; set; }

        public void AddBranch(string name, string createdBy)
        {
            if (this.Branches == null)
            {
                this.Branches = new List<Branch> { };
            }

            var branch = Branch.Factory.Create(this.TenantId, name, createdBy);
            this.Branches.Add(branch);
        }

        public void AddDrivers(DriverType driverType, string identificationType,
            string identificationNumber,
            string firstName,
            string lastName,
            string phone,
            string email,
            string createdBy)
        {
            if (this.Drivers == null)
            {
                this.Drivers = new List<Driver> { };
            }

            var driver = Driver.Factory.Create(this.TenantId, driverType, identificationType, identificationNumber, firstName, lastName, phone, email, createdBy);
            this.Drivers.Add(driver);
        }

        public static class Factory {
            public static Courier Create(string tenantId, string name, int sellerId, string sellerName, string createdBy)
            {
                var entity = new Courier
                {
                    TenantId = tenantId,
                    Name = name,
                    SellerId = sellerId,
                    SellerName = sellerName,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }
}
