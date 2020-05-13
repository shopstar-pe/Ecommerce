using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface ISellerRepository : IRepository<Seller>
    {
        Task<Seller> FindSellerById(string tenantId, int id);
        PagedResult<Seller> FindSellers(string tenantId, string name, int page, int pageSize);
    }
}
