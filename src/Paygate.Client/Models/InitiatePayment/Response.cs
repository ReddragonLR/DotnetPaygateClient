﻿using Newtonsoft.Json;
using Paygate.Client.Models.Common;

namespace Paygate.Client.Models.InitiatePayment
{
    public sealed class Response : ModelBase
    {
        public Response(string encryptionKey, string paygateId, string payRequestId, string paymentReference, string checksum)
            : base(encryptionKey)
        {
            PaygateId = paygateId;
            PayRequestId = payRequestId;
            PaymentReference = paymentReference;
            Checksum = checksum;
        }

        [JsonProperty("PAYGATE_ID")]
        [PartOfChecksum]
        public string PaygateId { get; set; }

        [JsonProperty("PAY_REQUEST_ID")]
        [PartOfChecksum]
        public string PayRequestId { get; set; }

        [JsonProperty("REFERENCE")]
        [PartOfChecksum]
        public string PaymentReference { get; set; }

        [JsonProperty("CHECKSUM")]
        public string Checksum { get; set; }
    }
}
