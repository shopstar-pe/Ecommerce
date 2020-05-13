using System;
namespace Payments.Domain.Entities
{
    public enum TransactionStatusType
    {
        Pending,
        Authorized,
        Captured,
        Cancelled
    }
}
