using System;
namespace Sales.Application.Commands.SaleOrderCommand.Models
{
    public class ClientModel
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }

        public string EntityName { get; set; }
        public string EntityIdentificationNumber { get; set; }
    }
}
