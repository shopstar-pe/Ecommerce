using System;
using System.Collections.Generic;

namespace Payments.Application.Abstractions.Models
{
    public class CancelRequestModel
    {
        public string OrderNumber { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }

        public Dictionary<string, string> Settings { get; set; }
    }
}
