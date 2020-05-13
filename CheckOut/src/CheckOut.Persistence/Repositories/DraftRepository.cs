using System;
using MediatR;
using CheckOut.Domain.Entities;
using CheckOut.Domain.Repositories;
using CheckOut.Persistence.Contexts;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using CheckOut.Domain.Paging;
using CheckOut.Persistence.Extensions;

namespace CheckOut.Persistence.Repositories
{
    public class DraftRepository : Repository<Draft>, IDraftRepository
    {
        public DraftRepository(CheckOutDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public async Task<Draft> FindByDraftId(string tenantId, string id)
        {
            id = id.ToLower();
            return await this.DbSet
                .Include(c=> c.Items).ThenInclude(x=> x.Services)
                .Include(c => c.Items).ThenInclude(x => x.Discounts)
                .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.DraftId.Equals(id) && c.EntityStatus != EntityStatus.Deleted );
        }

        public async Task<Draft> FindByDraftId(string tenantId, int sellerId, string id)
        {
            id = id.ToLower();
            var draft = await this.DbSet
                .Include(c => c.Items)
                    .ThenInclude(x => x.Variants)
                .Include(c => c.Items)
                    .ThenInclude(x => x.Services)
                .Include(c => c.Items)
                    .ThenInclude(x => x.Discounts)
                .FirstOrDefaultAsync(c => c.TenantId.Equals(tenantId) && c.DraftId.Equals(id) && c.EntityStatus != EntityStatus.Deleted);

            if (draft != null)
            {
                var draftItems = new List<DraftItem>();
                foreach (var item in draft.Items)
                {
                    if (item.SellerId.Equals(sellerId))
                    {
                        draftItems.Add(item);
                    }
                }

                draft.Items = draftItems;
            }

            return draft;
        }

        public PagedResult<Draft> FindDrafts(string tenantId, int? sellerId, int page, int pageSize)
        {
            var query = this.DbSet.Where(c =>tenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);


            if (sellerId.HasValue && sellerId.Value > 0)
                query = query.Where(c => c.Items.Any(c=> c.SellerId.Equals(sellerId.Value)));

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

    }
}
