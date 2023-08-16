using Newtonsoft.Json;
using Paygate.Client.Models.Common;
using Refit;
using System.Web;

namespace Paygate.Client.Models.PaymentNotification
{
    public sealed class Response
    {
        [AliasAs("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; set; }

        [AliasAs("PAY_REQUEST_ID")]
        [PartOfChecksum]
        public string PayRequestId { get; set; }

        [AliasAs("REFERENCE")]
        [PartOfChecksum]
        public string Reference { get; set; }

        [AliasAs("TRANSACTION_STATUS")]
        [PartOfChecksum]
        public string TransactionStatus { get; set; }

        [AliasAs("RESULT_CODE")]
        [PartOfChecksum]
        public string ResultCode { get; set; }

        [AliasAs("AUTH_CODE")]
        [PartOfChecksum]
        public string AuthCode { get; set; }

        [AliasAs("CURRENCY")]
        [PartOfChecksum]
        public string Currency { get; set; }

        [AliasAs("AMOUNT")]
        [PartOfChecksum]
        public double Amount { get; set; }

        [AliasAs("RESULT_DESC")]
        [PartOfChecksum]
        public string ResultDescription { get; set; }

        [AliasAs("TRANSACTION_ID")]
        [PartOfChecksum]
        public string TransactionId { get; set; }

        [AliasAs("RISK_INDICATOR")]
        [PartOfChecksum]
        public string RiskIndicator { get; set; }

        [AliasAs("PAY_METHOD")]
        [PartOfChecksum]
        public string PayMethod { get; set; }

        [AliasAs("PAY_METHOD_DETAIL")]
        [PartOfChecksum]
        public string PayMethodDetail { get; set; }

        [AliasAs("CHECKSUM")]
        public string Checksum { get; set; }

        public static Response FromPayload(string payload)
        {
            var keyValues = HttpUtility.ParseQueryString(payload);
            var response = new Response()
            {
                PaygateId = keyValues["PAYGATE_ID"],
                PayRequestId = keyValues["PAY_REQUEST_ID"],
                Reference = keyValues["REFERENCE"],
                TransactionStatus = keyValues["TRANSACTION_STATUS"],
                ResultCode = keyValues["RESULT_CODE"],
                AuthCode = keyValues["AUTH_CODE"],
                Currency = keyValues["CURRENCY"],
                Amount = Convert.ToDouble(keyValues["AMOUNT"]),
                ResultDescription = keyValues["RESULT_DESC"],
                TransactionId = keyValues["TRANSACTION_ID"],
                RiskIndicator = keyValues["RISK_INDICATOR"],
                PayMethod = keyValues["PAY_METHOD"],
                PayMethodDetail = keyValues["PAY_METHOD_DETAIL"],
                Checksum = keyValues["CHECKSUM"]
            };
            return response;
        }
    }
}
