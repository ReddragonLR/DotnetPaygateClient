using Paygate.Client.Models.Common;
using Refit;
using System.Text;
using System.Web;

namespace Paygate.Client.Models.InitiatePayment
{
    public sealed class Response
    {
        const string INITIATE_PAYMENT_URL = "https://secure.paygate.co.za/payweb3/process.trans";
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

        public string FormHTML { get; set; }
        public Uri InitiatePaymentUrl => new Uri(INITIATE_PAYMENT_URL);

        public static Response FromPayload(string payload)
        {
            var keyValues = HttpUtility.ParseQueryString(payload);
            var response = new Response
                (
                    keyValues["PAYGATE_ID"],
                    keyValues["PAY_REQUEST_ID"],
                    keyValues["REFERENCE"],
                    keyValues["CHECKSUM"]
                );
            response.FormHTML = MapFormHTML(response.PayRequestId, response.Checksum, response.InitiatePaymentUrl);
            return response;
        }

        private static string MapFormHTML(string payRequestId, string checksum, Uri initiatePaymentUrl)
        {
            StringBuilder htmlFormBuilder = new StringBuilder();
            htmlFormBuilder.Append($"<form action=\"{initiatePaymentUrl.AbsolutePath}\" method=\"POST\">");
            htmlFormBuilder.Append($"<input id=\"payrequestid\" name=\"PAY_REQUEST_ID\" value=\"{payRequestId}\">");
            htmlFormBuilder.Append($"<input id=\"checksum\" name=\"CHECKSUM\" value=\"{checksum}\">");
            htmlFormBuilder.Append("<input type=\"submit\">");
            htmlFormBuilder.Append("</form>");
            return htmlFormBuilder.ToString();
        }
    }
}
