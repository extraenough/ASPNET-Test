using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_Test2.CMC
{
    public class CMC_API_Call_CryptocurrencyInfoQueryResult
    {
        public CMC_API_Call_Status status { get; set; }
        public Dictionary<string, CMC_API_Call_CryptocurrencyInfo> data { get; set; }
    }
    
    public class CMC_API_Call_CryptocurrencyInfo
    {
        public int                                          id          { get; set; }
        public string                                       name        { get; set; }
        public string                                       symbol      { get; set; }
        public string                                       category    { get; set; }
        public string                                       slug        { get; set; }
        public string                                       logo        { get; set; }
        public string                                       description { get; set; }
        public DateTime                                     date_added  { get; set; }
        public IList<string>                                tags        { get; set; }
        public CMC_API_Call_CryptocurrencyPlatform   platform    { get; set; }
        public Dictionary<string, IList<string>>            urls        { get; set; }

    }
}