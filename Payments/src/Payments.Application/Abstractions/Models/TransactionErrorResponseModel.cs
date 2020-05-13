using System;
namespace Payments.Application.Abstractions.Models
{
    public class TransactionErrorResponseModel
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
