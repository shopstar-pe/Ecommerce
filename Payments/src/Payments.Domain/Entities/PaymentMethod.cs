using System;
namespace Payments.Domain.Entities
{
    /// <summary>
    /// Payment method availables by country
    /// Sample
    ///     - Visa
    ///     - Master Card
    ///     - American Express 
    ///     - Pago Efectivo
    ///     - Safety Pay
    ///     - Deposito en cuenta bancaria
    ///     - Custom
    /// </summary>
    public class PaymentMethod : BaseEntity
    {
        public PaymentMethod()
        {

        }

        public int PaymentMethodId { get; set; }
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool IsPublished { get; set; }
        public string IconLink { get; set; }

        public int PaymentMethodGroupId { get; set; }
        public virtual PaymentMethodGroup PaymentMethodGroup { get; set; }

        /// <summary>
        /// Sample => 99
        /// </summary>
        public string ValidatorCardCodeMask { get; set; }

        /// <summary>
        /// Sample => ^[0-9]{3}$
        /// </summary>
        public string ValidatorCardCodeRegex { get; set; }

        /// <summary>
        /// Sample => 9999 9999 9999 9999
        /// </summary>
        public string ValidatorCardMask { get; set; }

        /// <summary>
        /// Sample => ^4 
        /// </summary>
        public string ValidatorCardRegex { get; set; }

        public bool ValidatorCardUseCvv { get; set; }
        public bool ValidatorCardUseExpirationDate { get; set; }
        public bool ValidatorCardUseBillingAddress { get; set; }
    }
}
