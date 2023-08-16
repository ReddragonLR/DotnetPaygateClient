using Paygate.Client.Helpers;
using Paygate.Client.Models.Common;

namespace Paygate.Client.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void CreateMD5_Success()
        {
            // GIVEN
            const string expected = "59229d9c6cb336ae4bd287c87e6f0220";
            const string input = "10011072130pgtest_1234567893299ZARhttps://my.return.url/page2018-01-01 12:00:00en-zaZAFcustomer@paygate.co.zasecret";

            // WHEN
            var result = ChecksumHelper.CreateMD5(input);

            // THEN
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GenerateChecksumString_Success()
        {
            // GIVEN
            const string expected = "10011072130pgtest_1234567893299ZARhttps://my.return.url/page2018-01-01 12:00:00en-zaZAFcustomer@paygate.co.zahttps://my.return.url/pagesecret";

            // WHEN
            var request = new Models.InitiatePayment.Request("secret", "10011072130", "pgtest_123456789", 3299, Currencies.ZAR, new Uri("https://my.return.url/page"), new DateTime(2018, 1, 1, 12, 0, 0), "customer@paygate.co.za", new Uri("https://my.return.url/page"));

            // THEN
            var result = request.ExtractStringValuesWithAttribute() + "secret";
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GenerateChecksumValue_Success()
        {
            // GIVEN
            const string expected = "230bacb911660a43103727e9013df6d9";

            // WHEN
            var request = new Models.InitiatePayment.Request("secret", "10011072130", "pgtest_123456789", 3299, Currencies.ZAR, new Uri("https://my.return.url/page"), new DateTime(2018, 1, 1, 12, 0, 0), "customer@paygate.co.za", new Uri("https://my.return.url/page"));

            // THEN
            var result = request.GenerateChecksum("secret");
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
