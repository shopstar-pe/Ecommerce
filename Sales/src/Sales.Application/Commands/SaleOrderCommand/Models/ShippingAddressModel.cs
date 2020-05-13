using System;
namespace Sales.Application.Commands.SaleOrderCommand.Models
{
    public class ShippingAddressModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string AddressLine { get; set; }
        public string AddressNumber { get; set; }
        public string Reference { get; set; }
        public string CountryIsoCode { get; set; }
        public string PostalCode { get; set; }

        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
    }
}
