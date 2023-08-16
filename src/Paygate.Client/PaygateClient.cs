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

        public async Task<Models.InitiatePayment.Response> InitiatePayment(string paymentReference, double amount, Currency currency, Uri returnUrl, DateTime transactionDate, string emailAddress, Uri notifyUrl)
        {
            var request = new Models.InitiatePayment.Request(
                _encryptionKey,
                _paygateId,
                paymentReference,
                amount,
                currency,
                returnUrl,
                transactionDate,
                emailAddress,
                notifyUrl);
            var response = await _paygateApi.InitiateTransaction(request);
            
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Http error. Status code: {response.StatusCode} with reason: {response.Error.ReasonPhrase} and message: {response.Error.Message}");

            if (response.Content.Contains("ERROR"))
                throw new HttpRequestException($"Error from Paygate: {response.Content}");

            return Models.InitiatePayment.Response.FromPayload(response.Content);
        }

        public async Task<Models.PaymentNotification.Response> QueryTransaction(string payRequestId, string paymentReference)
        {
            var request = new Models.QueryTransaction.Request(
                _encryptionKey,
                _paygateId,
                payRequestId,
                paymentReference);
            var response = await _paygateApi.QueryTransaction(request);

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Http error. Status code: {response.StatusCode} with reason: {response.Error.ReasonPhrase} and message: {response.Error.Message}");

            if (response.Content.Contains("ERROR"))
                throw new HttpRequestException($"Error from Paygate: {response.Content}");

            return Models.PaymentNotification.Response.FromPayload(response.Content);
        }
    }
}
