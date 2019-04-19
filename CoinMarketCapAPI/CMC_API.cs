using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using ASPNET_Test2.Models;

namespace ASPNET_Test2.CMC
{
    public class CMC_API
    {
        private static string API_KEY = "7190d641-abc8-48e8-82fc-6e4a7f6a9c0d";
        
        public static string getCryptoCurrencyListingAPI
            (
                int    start                = 1,
                int    limit                = 30,
                string convert              = @"USD",
                string sort                 = @"market_cap",
                string sort_dir             = @"desc",
                string cryptocurrency_type  = @"all"
            ) 
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            queryString["start"]                = start.ToString();
            queryString["limit"]                = limit.ToString();
            queryString["convert"]              = convert;
            queryString["sort"]                 = sort;
            queryString["sort_dir"]             = sort_dir;
            queryString["cryptocurrency_type"]  = cryptocurrency_type;

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers["X-CMC_PRO_API_KEY"] = API_KEY;
            client.Headers["Accepts"] = "application/json";

            return client.DownloadString(URL.ToString());
        }
        
        public static string getCryptoCurrencyInfoAPI(string id, string symbol)
        {
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/info ");

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString["id"] = id;
            if(id.Length == 0)
                queryString["symbol"] = symbol;

            URL.Query = queryString.ToString();

            var client = new WebClient();
            client.Headers["X-CMC_PRO_API_KEY"] = API_KEY;
            client.Headers["Accepts"] = "application/json";
            return client.DownloadString(URL.ToString());
        }
        
        public CMC_API_Call_CryptocurrencyListingQueryResult getCryptoCurrencyListing
            (
                int     start               = 1,
                int     limit               = 30,
                string  convert             = @"USD",
                string  sort                = @"market_cap",
                string  sort_dir            = @"desc",
                string  cryptocurrency_type = @"all"
            ) 
        {
            var dataJSON = getCryptoCurrencyListingAPI(start, limit, convert, sort, sort_dir, cryptocurrency_type);
            var data = JsonConvert.DeserializeObject<CMC_API_Call_CryptocurrencyListingQueryResult>(dataJSON, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            return data;
        }

        public CMC_API_Call_CryptocurrencyInfoQueryResult getCryptoCurrencyInfo
            (
                string id     = @"", 
                string symbol = @""
            )
        {
            var dataJSON = getCryptoCurrencyInfoAPI(id, symbol);
            var data = JsonConvert.DeserializeObject<CMC_API_Call_CryptocurrencyInfoQueryResult>(dataJSON, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

            return data;
        }
    }
}