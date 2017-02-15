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

                var result2 = await stub.SumAsync(new[] { ValueTuple.Create("hoge", new int[] { 1, 2, 3 }) });

                foreach (var item in result2)
                {
                    //C#7
                    //item.id, item.sum, item.count
                    Console.WriteLine($"id: {item.Item1}, sum: {item.Item2}, count: {item.Item3}");
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
