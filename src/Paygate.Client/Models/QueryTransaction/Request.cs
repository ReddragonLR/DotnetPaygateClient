using Newtonsoft.Json;
using Paygate.Client.Models.Common;

namespace Paygate.Client.Models.QueryTransaction
{
    public sealed class Request : ModelBase
    {
        public Request(string encryptionKey, string paygateId, string payRequestId, string paymentReference)
            : base(encryptionKey)
        {
            PaygateId = paygateId;
            PayRequestId = payRequestId;
            PaymentReference = paymentReference;
        }

        [JsonProperty("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; private set; }

        [JsonProperty("PAY_REQUEST_ID")]
        [PartOfChecksum]
        public string PayRequestId { get; private set; }

        [JsonProperty("REFERENCE")]
        [PartOfChecksum]
        public string PaymentReference { get; private set; }

        [JsonProperty("CHECKSUM")]
        public string Checksum => GenerateChecksum(EncryptionKey);
    }
}
