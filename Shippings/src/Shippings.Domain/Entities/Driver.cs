using System;
namespace Shippings.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string TenantId { get; set; }

        public int DriverId { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public DriverType DriverType { get; set; }

        public string ExternalId { get; set; }
        public string ExternalName { get; set; }

        public int CourierId { get; set; }
        public virtual Courier Courier { get; set; }

        public static class Factory
        {
            public static Driver Create(string tenantId, DriverType driverType,
                string identificationType,
                string identificationNumber,
                string firstName, string lastName, string phone, string email, string createdBy)
            {
                var entity = new Driver
                {
                    TenantId = tenantId,
                    FirstName = firstName,
                    LastName = lastName,
                    IdentificationNumber = identificationNumber,
                    IdentificationType = identificationType,
                    Phone = phone,
                    Email = email,
                    DriverType = driverType,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = createdBy
                };

                return entity;
            }
        }
    }

    public enum DriverType
    {
        Motorcycle,
        Car,
        Bicycle,
        Scooter
    }
}
