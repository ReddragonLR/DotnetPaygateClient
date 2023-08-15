using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paygate.Client
{
    public class PaygateClient : IPaygateClient
    {
        private const string PAYGATE_PAYWEB3_BASE_URL = "https://secure.paygate.co.za/payweb3";
        private readonly IPaygateApi paygateApi;
        public PaygateClient()
        {
            paygateApi = RestService.For<IPaygateApi>(PAYGATE_PAYWEB3_BASE_URL);
        }
    }
}
