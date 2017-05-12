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

        static NetStitch.NetStitchClient client = new NetStitch.NetStitchClient("http://localhost:53407/");

        static async Task MainAsync()
        {
            try
            {
                var stub = client.Create<ISharedInterface>();
                var result = await stub.TallyAsync(new int[] { 100, 20, 3 });
                Console.WriteLine(result);

                var result2 = await stub.SumAsync(new[] { ("hoge", new int[] { 1, 2, 3 }) });

                foreach (var item in result2)
                {
                    //C#7
                    Console.WriteLine($"id: {item.id}, sum: {item.sum}, count: {item.count}");
                }
                
                Console.WriteLine();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
