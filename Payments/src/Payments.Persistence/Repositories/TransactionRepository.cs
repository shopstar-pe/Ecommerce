using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Payments.Domain.Entities;
using Payments.Domain.Paging;
using Payments.Domain.Repositories;
using Payments.Persistence.Contexts;
using Payments.Persistence.Extensions;

namespace Payments.Persistence.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(PaymentsDbContext context, IMediator mediator) : base(context, mediator)
        {

        }

        public PagedResult<Transaction> FindTransactions(string tenantId, int? sellerId, List<TransactionStatusType> status, string orderNumber, DateTime? transactionDateStart, DateTime? transactionDateEnd, int page, int pageSize)
        {
            var query = this.DbSet.Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (transactionDateStart.HasValue)
            {
                query = query.Where(c => c.TransactionDate >= transactionDateStart.Value);
            }

            if (transactionDateEnd.HasValue)
            {
                query = query.Where(c => c.TransactionDate <= transactionDateEnd.Value);
            }

            if (sellerId.HasValue && sellerId.Value > 0)
            {
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));
            }

            if (!string.IsNullOrEmpty(orderNumber))
                query = query.Where(c => c.OrderNumber.Equals(orderNumber));

            if (status != null && status.Count > 0)
            {
                query = query.Where(c => status.Contains(c.TransactionStatusType));
            }

            return query.GetPaged(page, pageSize, c => c.CreatedOn, "desc");
        }

        public async Task<dynamic> GetStats(string tenantId, int? sellerId, DateTime? transactionDateStart, DateTime? transactionDateEnd)
        {
            var query = this.DbSet.Where(c => c.TenantId.Equals(tenantId) && c.EntityStatus != EntityStatus.Deleted);

            if (transactionDateStart.HasValue)
            {
                query = query.Where(c => c.TransactionDate >= transactionDateStart.Value);
            }

            if (transactionDateEnd.HasValue)
            {
                query = query.Where(c => c.TransactionDate <= transactionDateEnd.Value);
            }

            if (sellerId.HasValue && sellerId.Value > 0)
            {
                query = query.Where(c => c.SellerId.Equals(sellerId.Value));
            }

            var transactionByStatus = await query.GroupBy(c => c.TransactionStatusType)
               .Select(c => new {
                   TransactionStatusType = c.Key,
                   TransactionStatusTypeName = c.Key.ToString(),
                   Total = c.Sum(x=> x.Amount),
                   Count = c.Count()
               })
               .ToListAsync();

            var lastTransactions = await query.Take(10).Select(c=> new {
                TransactionId = c.TransactionId,
                TransactionDate = c.TransactionDate,

                OrderId = c.OrderId,
                OrderNumber = c.OrderNumber,
                
                TransactionStatusType = c.TransactionStatusType,
                CardType = c.CardType,
                Amount = c.Amount,
                UpdatedOn = c.UpdatedOn
            }).OrderByDescending(c => c.UpdatedOn).ToListAsync();

            return new {
                transactionByStatus = transactionByStatus,
                lastTransactions = lastTransactions
            };
        }

    }
}
