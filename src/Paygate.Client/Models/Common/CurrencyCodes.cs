using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paygate.Client.Models.Common
{
    public class Currency
    {
        public Currency(string country, string coutryCode, string name, string code)
        {
            Country = country;
            CountryCode = coutryCode;
            Name = name;
            Code = code;
        }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }

    public static class Currencies
    {
        public static Currency ZAR => new Currency("South Africa", "ZAF", "Rand", "ZAR");
    }
}
