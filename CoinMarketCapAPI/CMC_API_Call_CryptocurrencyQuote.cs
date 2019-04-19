using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_Test2.CMC
{
    public class CMC_API_Call_CryptocurrencyQuote
    {
        public double   price               { get; set; }
        public double   volume_24h          { get; set; }
        public double   percent_change_1h   { get; set; }
        public double   percent_change_24h  { get; set; }
        public double   percent_change_7d   { get; set; }
        public double   market_cap          { get; set; }
        public DateTime last_updated        { get; set; }
    }
}