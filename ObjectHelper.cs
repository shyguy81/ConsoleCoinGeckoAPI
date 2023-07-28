using Newtonsoft.Json;

namespace CoinGecko
{
    static class ObjectHelper
    {
        public static string Dump<T>(this T x)
        {
            string json = JsonConvert.SerializeObject(x, Newtonsoft.Json.Formatting.Indented);
            //Console.WriteLine(json);
            return json;
        }
    }
}