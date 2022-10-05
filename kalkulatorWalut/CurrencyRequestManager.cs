using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Policy;

namespace kalkulatorWalut
{
    internal class CurrencyRequestManager
    {   
        public string GetUsdExchangeRate()
        {
            using(var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nbp.pl/api/exchangerates/rates/a/usd?format=json");
                var responseMessage = httpClient.SendAsync(request).Result;
                var responseContent = responseMessage.Content.ReadAsStringAsync().Result;

                var currencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(responseContent);

                return currencyInfo.Rates.First().Mid;
            }
        }
        public string GetChfExchangeRate()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nbp.pl/api/exchangerates/rates/a/chf?format=json");
                var responseMessage = httpClient.SendAsync(request).Result;
                var responseContent = responseMessage.Content.ReadAsStringAsync().Result;

                var currencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(responseContent);

                return currencyInfo.Rates.First().Mid;
            }
        }
        public string GetTryExchangeRate()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nbp.pl/api/exchangerates/rates/a/try?format=json");
                var responseMessage = httpClient.SendAsync(request).Result;
                var responseContent = responseMessage.Content.ReadAsStringAsync().Result;

                var currencyInfo = JsonConvert.DeserializeObject<CurrencyInfo>(responseContent);

                return currencyInfo.Rates.First().Mid;
            }
        }
        public string GetGoldExchangeRate()
        {
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nbp.pl/api/cenyzlota?format=json");
                var responseMessage = httpClient.SendAsync(request).Result;
                var responseContent = responseMessage.Content.ReadAsStringAsync().Result;

                GoldRateInfo[] goldRateInfos = JsonConvert.DeserializeObject<GoldRateInfo[]>(responseContent);

                return goldRateInfos.First().cena;
            }
        }

    }
    class CurrencyInfo
    {
        public string Table { get; set; }
        public string Currency { get; set; }
        public string Code { get; set; }
        public List<CurrencyRateInfo> Rates { get; set; }
    }
    class CurrencyRateInfo
    {
        public string No { get; set; }
        public string EffectiveDate { get; set; }
        public string Mid { get; set; }
    }
    class GoldRateInfo
    {
        public string data { get; set; }
        public string cena { get; set; }
    }
}
