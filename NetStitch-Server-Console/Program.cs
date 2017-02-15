using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NetStitch_Sample_CI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStitch_Server_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
            .UseWebListener()
            .UseStartup<Startup>()
            .UseUrls("http://localhost:12345")
            .Build();

            webHost.Run();
        }
        public class Startup
        {
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
                app.UseNetStitch(this.GetType());
            }
        }

        public class MyClass : ISharedInterface
        {
            public IList<ValueTuple<string, int, int>> Sum(IList<ValueTuple<string, int[]>> list)
                => list.Select(x => ValueTuple.Create(x.Item1, x.Item2.Sum(), x.Item2.Length)).ToArray();

            public int Tally(int[] array) => array.Sum();
        }

    }
}
