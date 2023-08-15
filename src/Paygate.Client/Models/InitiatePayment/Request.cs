using Newtonsoft.Json;
using Paygate.Client.Helpers;
using Paygate.Client.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paygate.Client.Models.InitiatePayment
{
    public sealed class Request
    {
        public Request(string paygateId, string paymentReference, decimal amount, Currency currency, Uri returnUrl, DateTime transactionDate, string emailAddress, Uri notifyUrl)
        {
            
        }

        [JsonProperty("PAYGATE_ID")]
        public string PaygateId { get; private set; }

        [JsonProperty("REFERENCE")]
        public string PaymentReference { get; private set; }

        [JsonProperty("AMOUNT")]
        public decimal Amount { get; private set; }

        [JsonProperty("CURRENCY")]
        public string Currency { get; private set; }

        [JsonProperty("RETURN_URL")]
        public string ReturnUrl { get; private set; }

        [JsonProperty("TRANSACTION_DATE")]
        public string TransactionDate { get; private set; }

        [JsonProperty("LOCALE")]
        public string Locale { get; private set; }

        [JsonProperty("COUNTRY")]
        public string Country { get; private set; }

        [JsonProperty("EMAIL")]
        public string Email { get; private set; }

        [JsonProperty("NOTIFY_URL")]
        public string NotifyUrl { get; private set; }

        [JsonProperty("CHECKSUM")]
        public string Checksum => ChecksumHelper.CreateMD5($"{PaygateId}{PaymentReference}{Amount}{Currency}{ReturnUrl}{TransactionDate}{Locale}{Country}{Email}{NotifyUrl}");
    }
}
