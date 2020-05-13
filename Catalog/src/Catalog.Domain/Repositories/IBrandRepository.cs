using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;

namespace Catalog.Domain.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        PagedResult<Brand> FindBrands(string tenantId, string name, BrandStatus? status, int page, int pageSize);
    }
}
