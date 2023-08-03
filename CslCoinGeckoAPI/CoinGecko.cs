using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace CoinGecko
{
    class CoinGecko
    {

        private static string baseAPI = "https://api.coingecko.com/api/v3";

        public static async Task<object> getExchangesAsync(){
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAPI + "/exchanges");
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            String jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<object>(jsonString);
        }

        public static object? getExchanges(){
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAPI + "/exchanges");
            //request.Headers.Add("Cookie", "__cf_bm=_rLiQaoVcUsmlG.SMth2TxWhEkrLuYNbJHvZfJWgUM0-1690535093-0-AWcBqAyND6kL1Q9ot6BTRmRUH7Ngi6USuahfXuaL3mTk2JMJ7zqRMYcQp3ukRbfxbzkmu8lLtrb2eQljf/2Iv9k=");
            HttpResponseMessage response = client.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            //string jsonString = response.Content.ToString();
            //return JsonConvert.DeserializeObject<string>(jsonString);
            var jsonReturn = JsonConvert.DeserializeObject<object>(response.Content.ReadAsStringAsync().Result);
            //Console.WriteLine("response::"+jsonReturn);
            return jsonReturn;
        }
        
        public static Coin GetCoinMarket(string ids, string vs_currency){
            string path = "/coins/markets?vs_currency="+vs_currency+"&ids="+ids;
            var options = new RestClientOptions(baseAPI)
                            {
                            MaxTimeout = -1,
                            };
            var client = new RestClient(options);
            var request = new RestRequest(path, Method.Get);
            RestResponse response = client.ExecuteAsync(request).Result;
            JArray cCoin = JArray.Parse(response.Content);
            if(cCoin.Count>0){
                Coin rCoin = new Coin(){
                    id=cCoin[0]["id"].ToString(),
                    symbol=cCoin[0]["symbol"].ToString(),
                    current_price=float.Parse(cCoin[0]["current_price"].ToString()),
                    ath=float.Parse(cCoin[0]["ath"].ToString()),
                    atl=float.Parse(cCoin[0]["atl"].ToString()),
                    total_volume=Int64.Parse(cCoin[0]["total_volume"].ToString()),
                    last_updated=DateTime.Parse(cCoin[0]["last_updated"].ToString()),
                    atl_date=DateTime.Parse(cCoin[0]["atl_date"].ToString()),
                    ath_date=DateTime.Parse(cCoin[0]["ath_date"].ToString())
                };
                return rCoin;
            }
            return new Coin();
        }
    
        
    }

    class Coin
    {
         public string id  { get; set; }
         public string symbol  { get; set; }
         public float current_price  { get; set; }

         public float ath  { get; set; }
        public DateTime ath_date { get; set; }
         public float atl  { get; set; }
        public DateTime atl_date { get; set; }
        public Int64 total_volume { get; set; }
        public DateTime last_updated { get; set; }
    }
}