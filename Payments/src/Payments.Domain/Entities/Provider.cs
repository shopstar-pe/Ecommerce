using System;
using System.Collections.Generic;

namespace Payments.Domain.Entities
{
    public class Provider : BaseEntity, IAggregateRoot
    {
        public int ProviderId { get; set; }
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }

        public bool PaymentCreditCard { get; set; }

        public virtual List<ProviderSetting> ProviderSettings { get; set; }
        public virtual List<Transaction> Transactions { get; set; }

    }
}
