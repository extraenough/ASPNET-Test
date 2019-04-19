using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPNET_Test2.CMC
{
    public class CMC_API_Call_CryptocurrencyListingQueryResult
    {
        public CMC_API_Call_Status status { get; set; }
        public IList<CMC_API_Call_CryptocurrencyListing> data { get; set; }
    }

    public class CMC_API_Call_CryptocurrencyListing
    {
        public int                                                            id { get; set; }
        public string                                                       name { get; set; }
        public string                                                     symbol { get; set; }
        public string                                                       slug { get; set; }
        public int                                                      cmc_rank { get; set; }
        public int                                              num_market_pairs { get; set; }
        public double                                         circulating_supply { get; set; }
        public double                                               total_supply { get; set; }
        public long?                                                  max_supply { get; set; }
        public DateTime                                             last_updated { get; set; }
        public DateTime                                               date_added { get; set; }
        public IList<string>                                                tags { get; set; }
        public CMC_API_Call_CryptocurrencyPlatform               platform { get; set; }
        public Dictionary<string, CMC_API_Call_CryptocurrencyQuote> quote { get; set; }

    }
}