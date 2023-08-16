using Newtonsoft.Json;
using Paygate.Client.Models.Common;
using Refit;

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
            Locale = "en-za";
            CountryCode = currency.CountryCode;
            Email = emailAddress;
            NotifyUrl = notifyUrl.AbsoluteUri;
            Checksum = GenerateChecksum(EncryptionKey);
        }

        [AliasAs("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; private set; }

        [AliasAs("REFERENCE")]
        [PartOfChecksum]
        public string PaymentReference { get; private set; }

        [AliasAs("AMOUNT")]
        [PartOfChecksum]
        public double Amount { get; private set; }

        [AliasAs("CURRENCY")]
        [PartOfChecksum]
        public string Currency { get; private set; }

        [AliasAs("RETURN_URL")]
        [PartOfChecksum]
        public string ReturnUrl { get; private set; }

        [AliasAs("TRANSACTION_DATE")]
        [PartOfChecksum]
        public string TransactionDate { get; private set; }

        [AliasAs("LOCALE")]
        [PartOfChecksum]
        public string Locale { get; private set; }

        [AliasAs("COUNTRY")]
        [PartOfChecksum]
        public string CountryCode { get; private set; }

        [AliasAs("EMAIL")]
        [PartOfChecksum]
        public string Email { get; private set; }

        [AliasAs("NOTIFY_URL")]
        [PartOfChecksum]
        public string NotifyUrl { get; private set; }

        [AliasAs("CHECKSUM")]
        public string Checksum { get; private set; }
    }
}
