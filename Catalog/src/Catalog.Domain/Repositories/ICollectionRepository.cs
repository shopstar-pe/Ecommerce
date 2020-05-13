using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface ICollectionRepository : IRepository<Collection>
    {
        PagedResult<Collection> FindCollections(string tenantId, int? sellerId, string name, int page, int pageSize);
        Task<Collection> FindCollectionById(string tenantId, int id);
        Task<List<Product>> FindProductsByCollectionId(string tenantId, int id);
    }
}
