using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Domain.Entities;
using Catalog.Domain.Paging;
using Catalog.Domain.Repositories;
using Catalog.Persistence.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

    }
}
