using System;
namespace Payments.Integration.VisaNet.Models
{
    public class AuthorizeResultModel
    {
        public AuthorizeHeaderResultModel Header { get; set; }
        public AuthorizeFulfillmentResultModel Fulfillment { get; set; }
        public AuthorizeOrderResultModel Order { get; set; }
        public AuthorizeTokenResultModel Token { get; set; }
        public AuthorizeDataMapResultModel DataMap { get; set; }
    }

    public class AuthorizeFailedResultModel
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public AuthorizeErrorDataResultModel Data { get; set; }
    }


    public class AuthorizeErrorDataResultModel
    {
        public string ACTION_CODE { get; set; }
        public string STATUS { get; set; }
        public string ACTION_DESCRIPTION { get; set; }
    }

    public class AuthorizeHeaderResultModel
    {
        public string EcoreTransactionUUID { get; set; }
        public long EcoreTransactionDate { get; set; }
        public int Millis { get; set; }
    }

    public class AuthorizeTokenResultModel
    {
        public string TokenId { get; set; }
        public long ExpireOn { get; set; }
    }

    public class AuthorizeFulfillmentResultModel
    {
        public string Channel { get; set; }
        public string MerchantId { get; set; }
        public string TerminalId { get; set; }
        public string CaptureType { get; set; }
        public bool Countable { get; set; }
        public bool FastPayment { get; set; }
        public string Signature { get; set; }
    }

    public class AuthorizeOrderResultModel
    {
        public string TokenId { get; set; }
        public string ProductId { get; set; }
        public string PurchaseNumber { get; set; }
        public decimal Amount { get; set; }
        public int Installment { get; set; }
        public string Currency { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal AuthorizedAmount { get; set; }
        public string AuthorizationCode { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionId { get; set; }
    }

    public class AuthorizeDataMapResultModel
    {
        public string CURRENCY { get; set; }
        public long TRANSACTION_DATE { get; set; }
        public string TERMINAL { get; set; }
        public string ACTION_CODE { get; set; }
        public string TRACE_NUMBER { get; set; }
        public string ECI_DESCRIPTION { get; set; }
        public string ECI { get; set; }
        public string CARD { get; set; }
        public string MERCHANT { get; set; }
        public string STATUS { get; set; }
        public string ADQUIRENTE { get; set; }
        public string ACTION_DESCRIPTION { get; set; }
        public string ID_UNICO { get; set; }
        public string AMOUNT { get; set; }
        public string AUTHORIZED_AMOUNT { get; set; }
        public string PROCESS_CODE { get; set; }
        public string TRANSACTION_ID { get; set; }
        public string AUTHORIZATION_CODE { get; set; }
        public string BRAND { get; set; }
    }
}
