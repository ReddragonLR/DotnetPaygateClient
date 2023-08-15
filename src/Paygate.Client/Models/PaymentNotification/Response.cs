using Newtonsoft.Json;
using Paygate.Client.Models.Common;
using System.Web;

namespace Paygate.Client.Models.PaymentNotification
{
    public sealed class Response : ModelBase
    {
        public Response(string encryptionKey)
            : base(encryptionKey)
        {
        }

        [JsonProperty("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; set; }

        [JsonProperty("PAY_REQUEST_ID")]
        [PartOfChecksum]
        public string PayRequestId { get; set; }

        [JsonProperty("REFERENCE")]
        [PartOfChecksum]
        public string Reference { get; set; }

        [JsonProperty("TRANSACTION_STATUS")]
        [PartOfChecksum]
        public string TransactionStatus { get; set; }

        [JsonProperty("RESULT_CODE")]
        [PartOfChecksum]
        public string ResultCode { get; set; }

        [JsonProperty("AUTH_CODE")]
        [PartOfChecksum]
        public string AuthCode { get; set; }

        [JsonProperty("CURRENCY")]
        [PartOfChecksum]
        public string Currency { get; set; }

        [JsonProperty("AMOUNT")]
        [PartOfChecksum]
        public double Amount { get; set; }

        [JsonProperty("RESULT_DESC")]
        [PartOfChecksum]
        public string ResultDescription { get; set; }

        [JsonProperty("TRANSACTION_ID")]
        [PartOfChecksum]
        public string TransactionId { get; set; }

        [JsonProperty("RISK_INDICATOR")]
        [PartOfChecksum]
        public string RiskIndicator { get; set; }

        [JsonProperty("PAY_METHOD")]
        [PartOfChecksum]
        public string PayMethod { get; set; }

        [JsonProperty("PAY_METHOD_DETAIL")]
        [PartOfChecksum]
        public string PayMethodDetail { get; set; }

        [JsonProperty("CHECKSUM")]
        public string Checksum { get; set; }

        public static Response FromPayload(string encryptionKey, string data)
        {
            var keyValues = HttpUtility.ParseQueryString(data);
            var response = new Response(encryptionKey)
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
