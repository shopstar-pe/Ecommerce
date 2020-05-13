using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Payments.Domain.Entities;
using Payments.Domain.Paging;

namespace Payments.Domain.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        PagedResult<Transaction> FindTransactions(string tenantId, int? sellerId, List<TransactionStatusType> status, string orderNumber, DateTime? transactionDateStart, DateTime? transactionDateEnd, int page, int pageSize);
        Task<dynamic> GetStats(string tenantId, int? sellerId, DateTime? transactionDateStart, DateTime? transactionDateEnd);
    }
}
