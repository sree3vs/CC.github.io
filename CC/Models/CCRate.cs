using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CC.Models
{
    public class CCRate
    {
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public double ConversionRate { get; set; }
    }
}