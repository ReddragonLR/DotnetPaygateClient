using Newtonsoft.Json;
using Paygate.Client.Helpers;

namespace Paygate.Client.Models.InitiatePayment
{
    public sealed class Response
    {
        [JsonProperty("PAYGATE_ID")]
        public string PaygateId { get; set; }

        [JsonProperty("PAY_REQUEST_ID")]
        public string PayRequestId { get; set; }

        [JsonProperty("REFERENCE")]
        public string PaymentReference { get; set; }

        [JsonProperty("CHECKSUM")]
        public string Checksum { get; set; }

        public bool IsChecksumValid
        {
            get
            {
                if (string.IsNullOrEmpty(Checksum)) return false;

                var calculatedString = $"{PaygateId}{PayRequestId}{PaymentReference}";
                var calculatedChecksum = ChecksumHelper.CreateMD5(calculatedString);
                return string.Equals(calculatedChecksum, Checksum);
            }
        }
    }
}
