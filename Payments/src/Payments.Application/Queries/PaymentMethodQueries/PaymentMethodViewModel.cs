using System;
using System.Collections.Generic;

namespace Payments.Application.Queries.PaymentMethodQueries
{
    
    public class PaymentMethodListViewModel : PaymentMethodViewModel
    {
        
    }

    public class PaymentMethodViewModel
    {
        public int PaymentMethodId { get; set; }
        public string CountryIsoCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string IconLink { get; set; }
    }

    public class PaymentMethodGroupViewModel
    {
        public int PaymentMethodGroupId { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string CountryIsoCode { get; set; }
        public int Order { get; set; }
        public bool Enabled { get; set; }
        public List<PaymentMethodListViewModel> PaymentMethods { get; set; }
    }

}
