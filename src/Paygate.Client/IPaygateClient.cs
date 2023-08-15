using Paygate.Client.Models.Common;

namespace Paygate.Client
{
    public interface IPaygateClient
    {
        Task<Models.InitiatePayment.Response> InitiatePayment(string paymentReference, double amount, Currency currency, Uri returnUrl, DateTime transactionDate, string emailAddress, Uri notifyUrl);
        Task<Models.PaymentNotification.Response> QueryTransaction(string payRequestId, string paymentReference);
    }
}
