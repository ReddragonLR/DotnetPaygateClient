using Refit;

namespace Paygate.Client
{
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    internal interface IPaygateApi
    {
        [Post("/initiate.trans")]
        Task<ApiResponse<string>> InitiateTransaction([Body(BodySerializationMethod.UrlEncoded)] Models.InitiatePayment.Request request);

        [Post("/query.trans")]
        Task<ApiResponse<string>> QueryTransaction([Body(BodySerializationMethod.UrlEncoded)] Models.QueryTransaction.Request request);
    }
}