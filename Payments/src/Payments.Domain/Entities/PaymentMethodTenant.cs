using System;
namespace Payments.Domain.Entities
{
    public class PaymentMethodTenant : BaseEntity
    {
        public int PaymentMethodTenantId { get; set; }

        public string TenantId { get; set; }

        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }

        public string Comment { get; set; }
    }
}
