using Refit;

namespace Paygate.Client
{
    [Headers("Content-Type: application/x-www-form-urlencoded")]
    internal interface IPaygateApi
    {
        [Post("/initiate.trans")]
        Task<ApiResponse<string>> InitiateTransaction([Body(BodySerializationMethod.Default)] Models.InitiatePayment.Request request);

        [Post("/query.trans")]
        Task<ApiResponse<string>> QueryTransaction([Body(BodySerializationMethod.Default)] Models.QueryTransaction.Request request);
    }
}