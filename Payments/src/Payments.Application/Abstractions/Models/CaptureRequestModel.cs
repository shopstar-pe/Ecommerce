using System;
using System.Collections.Generic;

namespace Payments.Application.Abstractions.Models
{
    public class CaptureRequestModel
    {
        public string OrderNumber { get; set; }
        public string Token { get; set; }
        public string TransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal AuthorizedAmount { get; set; }
        public string CurrencyIsoCode { get; set; }
        public string Type { get; set; }

        public Dictionary<string, string> Settings { get; set; }
    }
}
