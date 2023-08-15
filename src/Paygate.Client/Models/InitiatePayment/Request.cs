using Newtonsoft.Json;
using Paygate.Client.Models.Common;

namespace Paygate.Client.Models.InitiatePayment
{
    public sealed class Request : ModelBase
    {
        public Request(string encryptionKey, string paygateId, string paymentReference, double amount, Currency currency, Uri returnUrl, DateTime transactionDate, string emailAddress, Uri notifyUrl)
            : base(encryptionKey)
        {
            PaygateId = paygateId;
            PaymentReference = paymentReference;
            Amount = amount;
            Currency = currency.Code;
            ReturnUrl = returnUrl.AbsoluteUri;
            TransactionDate = transactionDate.ToString("yyyy-MM-dd HH:mm:ss");
            Locale = Locales.en.ToString();
            Country = currency.Country;
            Email = emailAddress;
            NotifyUrl = notifyUrl.AbsoluteUri;
        }

        [JsonProperty("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; private set; }

        [JsonProperty("REFERENCE")]
        [PartOfChecksum]
        public string PaymentReference { get; private set; }

        [JsonProperty("AMOUNT")]
        [PartOfChecksum]
        public double Amount { get; private set; }

        [JsonProperty("CURRENCY")]
        [PartOfChecksum]
        public string Currency { get; private set; }

        [JsonProperty("RETURN_URL")]
        [PartOfChecksum]
        public string ReturnUrl { get; private set; }

        [JsonProperty("TRANSACTION_DATE")]
        [PartOfChecksum]
        public string TransactionDate { get; private set; }

        [JsonProperty("LOCALE")]
        [PartOfChecksum]
        public string Locale { get; private set; }

        [JsonProperty("COUNTRY")]
        [PartOfChecksum]
        public string Country { get; private set; }

        [JsonProperty("EMAIL")]
        [PartOfChecksum]
        public string Email { get; private set; }

        [JsonProperty("NOTIFY_URL")]
        [PartOfChecksum]
        public string NotifyUrl { get; private set; }

        [JsonProperty("CHECKSUM")]
        public string Checksum => GenerateChecksum(EncryptionKey);
    }
}
