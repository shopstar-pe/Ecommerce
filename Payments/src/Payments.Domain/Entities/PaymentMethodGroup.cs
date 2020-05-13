using System;
using System.Collections.Generic;

namespace Payments.Domain.Entities
{
    /// <summary>
    /// Payment Group 
    /// Sample
    ///     - Cash
    ///     - Credit Card
    ///     - Bank Deposit
    ///     - CashOnDelivery
    ///     - Manual
    ///     - Custom
    /// </summary>
    public class PaymentMethodGroup : BaseEntity
    {
        public PaymentMethodGroup() : base()
        {

        }

        public int PaymentMethodGroupId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Label system
        ///     -Cash
        ///     -CreditCard
        ///     -BankDeposit
        ///     -CashOnDelivery
        ///     -Manual
        ///     -Custom
        /// </summary>
        public string Label { get; set; }
        public string Description { get; set; }
        public string CountryIsoCode { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }

        public virtual List<PaymentMethod> PaymentMethods { get; set; }

    }
}
