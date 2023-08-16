using Newtonsoft.Json;
using Paygate.Client.Models.Common;
using Refit;
using System.Web;

namespace Paygate.Client.Models.InitiatePayment
{
    public sealed class Response
    {
        public Response(string paygateId, string payRequestId, string paymentReference, string checksum)
        {
            PaygateId = paygateId;
            PayRequestId = payRequestId;
            PaymentReference = paymentReference;
            Checksum = checksum;
        }

        [AliasAs("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; set; }

        [AliasAs("PAY_REQUEST_ID")]
        [PartOfChecksum]
        public string PayRequestId { get; set; }

        [AliasAs("REFERENCE")]
        [PartOfChecksum]
        public string PaymentReference { get; set; }

        [AliasAs("CHECKSUM")]
        public string Checksum { get; set; }

        public static Response FromPayload(string payload)
        {
            var keyValues = HttpUtility.ParseQueryString(payload);
            return new Response
                (
                    keyValues["PAYGATE_ID"],
                    keyValues["PAY_REQUEST_ID"],
                    keyValues["REFERENCE"],
                    keyValues["CHECKSUM"]
                );
        }
    }
}
