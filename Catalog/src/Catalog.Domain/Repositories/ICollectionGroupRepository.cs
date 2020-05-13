using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface ICollectionGroupRepository : IRepository<CollectionGroup>
    {
        PagedResult<CollectionGroup> FindCollectionGroups(string tenantId, int? sellerId, string name, int page, int pageSize);
        Task<CollectionGroup> FindCollectionGroupById(string tenantId, int id);
    }
}
