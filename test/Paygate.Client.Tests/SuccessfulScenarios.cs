using System.Text;

namespace Paygate.Client.Tests
{
    [TestFixture]
    public partial class SuccessfulScenarios
    {
        [Scenario]
        [ScenarioCategory("Successful Payments")]
        public void InitiatePayment()
        {
            Runner.RunScenario(
                Given_a_valid_test_client,
                When_a_valid_payment_is_initiated,
                Then_Paygate_returns_success);
        }

        [Scenario]
        [ScenarioCategory("Successful Payments")]
        public void GenerateValidChecksum()
        {
            Runner.RunScenario(
                Given_a_valid_initiate_payment_request,
                Then_the_checksum_must_be_valid);
        }
    }
}
