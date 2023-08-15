using Paygate.Client.Models.Common;
using Refit;

namespace Paygate.Client
{
    public class PaygateClient : IPaygateClient
    {
        private const string PAYGATE_PAYWEB3_BASE_URL = "https://secure.paygate.co.za/payweb3";
        private readonly IPaygateApi _paygateApi;
        private readonly string _encryptionKey = string.Empty;
        private readonly string _paygateId = string.Empty;
        public PaygateClient(string encryptionKey, string paygateId)
        {
            _paygateApi = RestService.For<IPaygateApi>(PAYGATE_PAYWEB3_BASE_URL);
            _encryptionKey = encryptionKey;
            _paygateId = paygateId;
        }

        public Task<Models.InitiatePayment.Response> InitiatePayment(string paymentReference, double amount, Currency currency, Uri returnUrl, DateTime transactionDate, string emailAddress, Uri notifyUrl)
        {
            return _paygateApi.InitiateTransaction(new Models.InitiatePayment.Request
                (
                _encryptionKey,
                _paygateId,
                paymentReference,
                amount,
                currency,
                returnUrl,
                transactionDate,
                emailAddress,
                notifyUrl
                ));
        }

        public Task<Models.PaymentNotification.Response> QueryTransaction(string payRequestId, string paymentReference)
        {
            return _paygateApi.QueryTransaction(new Models.QueryTransaction.Request
                (
                _encryptionKey,
                _paygateId,
                payRequestId,
                paymentReference
                ));
        }
    }
}
