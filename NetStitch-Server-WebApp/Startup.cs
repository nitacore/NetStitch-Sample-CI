using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace NetStitch_Server_WebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseNetStitch(typeof(Startup));
        }

        public class Test : NetStitch_Sample_CI.ISharedInterface
        {
            public async ValueTask<IList<(string id, int sum, int count)>> SumAsync(IList<(string id, int[] targets)> list)
            {
                return list.Select(x => (x.id, x.targets.Sum(), x.targets.Length)).ToList();
            }

            public async ValueTask<int> TallyAsync(int[] array)
            {
                return array.Sum();
            }
        }

    }
}
