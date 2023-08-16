using Newtonsoft.Json;
using Paygate.Client.Models.Common;
using Refit;

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

        [AliasAs("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; private set; }

        [AliasAs("PAY_REQUEST_ID")]
        [PartOfChecksum]
        public string PayRequestId { get; private set; }

        [AliasAs("REFERENCE")]
        [PartOfChecksum]
        public string PaymentReference { get; private set; }

        [AliasAs("CHECKSUM")]
        public string Checksum => GenerateChecksum(EncryptionKey);
    }
}
