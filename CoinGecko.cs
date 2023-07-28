using System.Threading.Tasks;
using Newtonsoft.Json;

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
        
    }
}