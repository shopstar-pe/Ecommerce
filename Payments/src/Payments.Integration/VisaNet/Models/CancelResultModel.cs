using System;
namespace Payments.Integration.VisaNet.Models
{
    public class CancelResultModel
    {
        public CancelHeaderResultModel Header { get; set; }
        public CancelOrderResultModel Order { get; set; }
        public CancelDataMapResultModel DataMap { get; set; }
    }

    public class CancelFailedResultModel
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public CancelErrorDataResultModel Data { get; set; }
    }

    public class CancelErrorDataResultModel
    {
        public string ACTION_CODE { get; set; }
        public string STATUS { get; set; }
        public string ACTION_DESCRIPTION { get; set; }
    }

    public class CancelHeaderResultModel
    {
        public string EcoreTransactionUUID { get; set; }
        public long EcoreTransactionDate { get; set; }
        public int Millis { get; set; }
    }

    public class CancelOrderResultModel
    {
        public string ProductId { get; set; }
        public string PurchaseNumber { get; set; }
        public decimal Amount { get; set; }
        public int Installment { get; set; }
        public string Currency { get; set; }
        public string ExternalTransactionId { get; set; }
        public decimal CanceldAmount { get; set; }
        public string AuthorizationCode { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionId { get; set; }
    }

    public class CancelDataMapResultModel
    {
        public string CURRENCY { get; set; }
        public long TRANSACTION_DATE { get; set; }
        public string TERMINAL { get; set; }
        public string ACTION_CODE { get; set; }
        public string TRACE_NUMBER { get; set; }
        public string ECI_DESCRIPTION { get; set; }
        public string ECI { get; set; }
        public string MERCHANT { get; set; }
        public string STATUS { get; set; }
        public string ADQUIRENTE { get; set; }
        public string ACTION_DESCRIPTION { get; set; }
        public string ID_UNICO { get; set; }
        public string AMOUNT { get; set; }
        public string PROCESS_CODE { get; set; }
        public string TRANSACTION_ID { get; set; }
        public string AUTHORIZATION_CODE { get; set; }
    }
}
