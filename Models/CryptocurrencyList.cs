using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPNET_Test2.CMC;

namespace ASPNET_Test2.Models
{
    public class CryptocurrencyList 
    {
        public List<Cryptocurrency>   data { get; set; }
        public List<int>        showListId { get; set; }

        public CryptocurrencyList() 
        {
            data = new List<Cryptocurrency>();
            showListId = new List<int>();

            var CryptocurrencyListing = new CMC_API_Call_CryptocurrencyListingQueryResult();
            var CryptocurrencyInfo = new CMC_API_Call_CryptocurrencyInfoQueryResult();
            var CoinMarketAPI = new CMC_API();
            try
            {
                CryptocurrencyListing = CoinMarketAPI.getCryptoCurrencyListing(1, 30, @"USD", @"market_cap", @"desc", @"all");
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }

            string CryptocurrencyID = @"";
            foreach (var Cryptocurrency in CryptocurrencyListing.data) { CryptocurrencyID += ',' + Cryptocurrency.id.ToString(); }
            CryptocurrencyID = CryptocurrencyID.Remove(0, 1);

            try
            {
                CryptocurrencyInfo = CoinMarketAPI.getCryptoCurrencyInfo(CryptocurrencyID);
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
            }

            setData(CryptocurrencyListing, CryptocurrencyInfo);
            search();
        }

        public void setData
            (
                CMC_API_Call_CryptocurrencyListingQueryResult CryptocurrencyListing,
                CMC_API_Call_CryptocurrencyInfoQueryResult CryptocurrencyInfo
            )
        {
            foreach (var item in CryptocurrencyListing.data)
            {
                data.Add(new Cryptocurrency()
                {
                    id = item.id,
                    index = data.Count,
                    name = item.name,
                    symbol = item.symbol,
                    logo = CryptocurrencyInfo.data[item.id.ToString()].logo,
                    price = item.quote["USD"].price,
                    percent_change_1h = item.quote["USD"].percent_change_1h,
                    percent_change_24h = item.quote["USD"].percent_change_24h,
                    market_cap = item.quote["USD"].market_cap,
                    last_updated = item.quote["USD"].last_updated
                });

            }
        }

        public void search(string name = @"") 
        {
            showListId.Clear();
            if (name.Length != 0)
            {
                foreach (var item in data.Where(x => x.name.Contains(name)).ToList()) 
                {
                    showListId.Add(item.id);
                }
            }
            else {
                foreach (var item in data) { showListId.Add(item.id); }
            }
        }
    }

    public class Cryptocurrency
    {
        public int      id                  { get; set; }
        public int      index               { get; set; }
        public string   name                { get; set; }
        public string   symbol              { get; set; }
        public string   logo                { get; set; }
        public double   price               { get; set; }
        public double   percent_change_1h   { get; set; }
        public double   percent_change_24h  { get; set; }
        public double   market_cap          { get; set; }
        public DateTime last_updated        { get; set; }
    }
}