﻿using Microsoft.AspNetCore.Builder;
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
            public async ValueTask<IList<(string id, int sum, int count)>> SumAsync(IList<(string id, int[] targets)> list)
            {
                return list.Select(x => (x.id, x.targets.Sum(), x.targets.Length)).ToArray();
            }

            public async ValueTask<int> TallyAsync(int[] array)
            {
                return array.Sum();
            }
        }

    }
}
