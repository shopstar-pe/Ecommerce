using System;
using System.Collections.Generic;

namespace Payments.Application.Abstractions.Models
{
    public class AuthorizeResponseModel
    {
        public bool Success { get; set; }

        public string Token { get; set; }
        public string AuthCode { get; set; }
        public string TransactionId { get; set; }
        public DateTime TransationDate { get; set; }
        public List<TransactionErrorResponseModel> Errors { get; set; }
        public decimal Amount { get; set; }
        public decimal AuthorizedAmount { get; set; }
        public string OrderNumber { get; set; }
        public string PlaceHolder { get; set; }
        public string CardNumber { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string CardType { get; set; }
    }
}
