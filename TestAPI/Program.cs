using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestAPI
{
    class Program
    {

        public static async Task test()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja");
            var response = await client.GetAsync("/fact");
            var catstring = await response.Content.ReadAsStringAsync();
            Console.WriteLine(catstring);
        }
        
        static async Task Main(string[] args)
        {

            await test();

            /*
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://catfact.ninja");
            string response = client.GetAsync("/fact").Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(response);
            */
        }

    }
}
