using CommandLine;

namespace CoinGecko
{
    class Program
    {
        public class Options
        {
            [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
            public bool Verbose { get; set; }
        }

        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");

            Parser.Default.ParseArguments<Options>(args)
                   .WithParsed<Options>(o =>
                   {
                       if (o.Verbose)
                       {
                           Console.WriteLine($"Verbose output enabled. Current Arguments: -v {o.Verbose}");
                           Console.WriteLine("Quick Start Example! App is in Verbose mode!");
                       }
                       else
                       {
                           bool showMenu = true;
                           while (showMenu)
                           {
                               showMenu = MainMenu();
                           }
                       }
                   });
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Get BITCOIN datas");
            Console.WriteLine("2) Get ETHEREUM datas");
            Console.WriteLine("3) Get SWEAT datas");
            Console.WriteLine("4) Get NEAR datas");
            //Console.WriteLine("2) Remove Whitespace");
            Console.WriteLine("99) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "3":
                    Coin? newSweat = CoinGecko.GetCoinMarket(ids: "sweatcoin", vs_currency: "usd");
                    Console.WriteLine(newSweat.Dump());
                    //Console.WriteLine(newObj);
                    Console.Write("\r\nPress Enter to return to Main Menu");
                    Console.ReadLine();
                    return true;
                case "4":
                    Coin? newNear = CoinGecko.GetCoinMarket(ids: "near", vs_currency: "usd");
                    Console.WriteLine(newNear.Dump());
                    //Console.WriteLine(newObj);
                    Console.Write("\r\nPress Enter to return to Main Menu");
                    Console.ReadLine();
                    return true;
                case "2":
                    Coin? newEth = CoinGecko.GetCoinMarket(ids: "ethereum", vs_currency: "usd");
                    Console.WriteLine(newEth.Dump());
                    //Console.WriteLine(newObj);
                    Console.Write("\r\nPress Enter to return to Main Menu");
                    Console.ReadLine();
                    return true;
                case "1":
                    Coin? newBtc = CoinGecko.GetCoinMarket(ids: "bitcoin", vs_currency: "usd");
                    Console.WriteLine(newBtc.Dump());
                    //Console.WriteLine(newObj);
                    Console.Write("\r\nPress Enter to return to Main Menu");
                    Console.ReadLine();
                    return true;
                default:
                    return false;
            }
        }
    }
}