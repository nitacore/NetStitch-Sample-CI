using NetStitch_Sample_CI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStitch_Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
            Console.ReadLine();
        }

        static NetStitch.NetStitchClient client = new NetStitch.NetStitchClient("http://localhost:12345");

        static async Task MainAsync()
        {
            try
            {
                var stub = client.Create<ISharedInterface>();
                var result = await stub.TallyAsync(new int[] { 100, 20, 3 });
                Console.WriteLine(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
