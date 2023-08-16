using Paygate.Client.Models.Common;
using Paygate.Client.Tests.Fixtures;

namespace Paygate.Client.Tests
{
    public partial class SuccessfulScenarios : BaseScenario
    {
        private IPaygateClient paygateClient;
        private Models.InitiatePayment.Response result;
        private Models.InitiatePayment.Request request;
        private void Given_a_valid_test_client()
        {
            paygateClient = new PaygateClient("secret", "10011072130");
        }

        private void When_a_valid_payment_is_initiated()
        {
            result = paygateClient.InitiatePayment(
                "pgtest_123456789",
                3299,
                Currencies.ZAR,
                new Uri("https://my.return.url/page"),
                new DateTime(2018, 1, 1, 12, 0, 0),
                "customer@paygate.co.za",
                new Uri("https://my.return.url/page")).GetAwaiter().GetResult();
        }

        private void Then_Paygate_returns_success()
        {
            Assert.That(result.PaygateId, Is.EqualTo("10011072130"));
            Assert.IsFalse(string.IsNullOrEmpty(result.PayRequestId));
            Assert.That(result.PaymentReference, Is.EqualTo("pgtest_123456789"));
            Assert.IsFalse(string.IsNullOrEmpty(result.Checksum));
        }

        private void Given_a_valid_initiate_payment_request()
        {
            request = new Models.InitiatePayment.Request("secret", "10011072130", "pgtest_123456789", 3299, Currencies.ZAR, new Uri("https://my.return.url/page"), new DateTime(2018, 1, 1, 12, 0, 0), "customer@paygate.co.za", new Uri("https://my.return.url/page"));
        }

        private void Then_the_checksum_must_be_valid()
        {
            Assert.That(request.Checksum, Is.EqualTo("230bacb911660a43103727e9013df6d9"));
        }
    }
}
