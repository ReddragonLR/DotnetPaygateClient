using Refit;

namespace Paygate.Client
{
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    internal interface IPaygateApi
    {
        [Post("/initiate.trans")]
        Task<Models.InitiatePayment.Response> InitiateTransaction([Body] Models.InitiatePayment.Request request);

        [Post("/query.trans")]
        Task<Models.PaymentNotification.Response> QueryTransaction([Body] Models.QueryTransaction.Request request);
    }
}