using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_Test2.CMC
{
    public class CMC_API_Call_CryptocurrencyPlatform
    {
        public int    id            { get; set; }
        public string name          { get; set; }
        public string symbol        { get; set; }
        public string slug          { get; set; }
        public string token_address { get; set; }
    }
}