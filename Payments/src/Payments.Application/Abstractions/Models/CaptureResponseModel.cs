using System;
using System.Collections.Generic;

namespace Payments.Application.Abstractions.Models
{
    public class CaptureResponseModel
    {
        public bool Success { get; set; }
        public string TransactionId { get; set; }
        public List<TransactionErrorResponseModel> Errors { get; set; }
    }
}
