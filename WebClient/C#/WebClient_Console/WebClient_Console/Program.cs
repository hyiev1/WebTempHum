using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
// Visual Studio -> View -> Other Windows -> Package Manager Console -> "Install-Package Newtonsoft.Json"
using Newtonsoft.Json;

namespace WebClient_Console
{
    class Program
    {
        public static async Task<dynamic> createRequest(string url)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(url);
            dynamic json = JsonConvert.DeserializeObject(result);
            return json;
        }

        static async Task Main(string[] args)
        {
            string url;
            do
            {
                Console.Write("Enter Address (Example: http://XX.XX.XX.XX/info): ");
                url = Console.ReadLine();
            } while (String.IsNullOrEmpty(url.Trim()));

            while(true)
            {
                try
                {
                    dynamic response = await createRequest(url);

                    Console.WriteLine("----- ----- ----- -----");
                    Console.WriteLine("Temperature: " + response.temperature);
                    Console.WriteLine("Humidity:    " + response.humidity);
                } 
                catch(Exception exception)
                {
                    Console.WriteLine("----- ----- ----- -----");
                    Console.WriteLine("ERROR: " + exception.Message);
                    Console.WriteLine("Stopped Thread!");
                    break;
                }

                Thread.Sleep(10000); // 10sec

            }

        }
    }
}
