using CC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CC.Controllers
{
    public class ConvertController : ApiController
    {
        private CCRate[] rates = new CCRate[]
        {
            new CCRate { BaseCurrency = "USD", TargetCurrency = "INR", ConversionRate = 71.03 },
            new CCRate { BaseCurrency = "USD", TargetCurrency = "SGD", ConversionRate = 1.38 },
            new CCRate { BaseCurrency = "INR", TargetCurrency = "CNY", ConversionRate = 0.10 },
            new CCRate { BaseCurrency = "MYR", TargetCurrency = "USD", ConversionRate = 0.24 },
            new CCRate { BaseCurrency = "EUR", TargetCurrency = "GBP", ConversionRate = 0.88 },
            new CCRate { BaseCurrency = "DHR", TargetCurrency = "INR", ConversionRate = 19.34 }
        };

        public IEnumerable<CCRate> GetAll()
        {
            return rates;
        }

        public IHttpActionResult GetSpecificRate(string baseCurrency, string targetCurrency)
        {
            var rate = rates.Where(c => c.BaseCurrency == baseCurrency && c.TargetCurrency == targetCurrency).FirstOrDefault();
            if (rate == null)
            {
                return NotFound();
            }
            return Ok(rate);
        }

        [Route("api/convert/greet")]
        public IHttpActionResult GetGreeting(string baseCurrency, string targetCurrency)
        {
            var result = "Hi How are you?";
            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult DoConversion(string baseCurrency, string targetCurrency, double amount)
        {
            var rate = rates.Where(c => c.BaseCurrency == baseCurrency && c.TargetCurrency == targetCurrency).FirstOrDefault();
            var convertedAmount = amount * rate.ConversionRate;
            if(rate==null) { return NotFound(); }
            return Ok(convertedAmount);
        }
    }
}
