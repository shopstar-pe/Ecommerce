using System;
using System.Collections.Generic;

namespace Sales.Application.Queries.ClientQueries
{
    
    public class ClientListViewModel : ClientViewModel
    {
    }

    public class ClientViewModel
    {
        public string TenantId { get; set; }

        public int ClientId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string IdentificationNumber { get; set; }
        public string IdentificationType { get; set; }
        public string EntityName { get; set; }
    }

}
