using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Paging;

namespace CheckOut.Domain.Repositories
{
    public interface IDraftRepository : IRepository<Draft>
    {
        Task<Draft> FindByDraftId(string tenantId, string id);
        Task<Draft> FindByDraftId(string tenantId, int sellerId, string id);
        PagedResult<Draft> FindDrafts(string tenantId, int? sellerId, int page, int pageSize);

    }
}
