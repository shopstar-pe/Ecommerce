using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sales.Domain.Entities;
using Sales.Domain.Paging;

namespace Sales.Domain.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> FindClientByEmail(string tenantId, string email);
        Task<Client> FindClientById(string tenantId, int id);
        PagedResult<Client> FindClients(string tenantId, string q, int? sellerId, int page, int pageSize);
    }
}
