using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliciousService.SomeCode;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeliciousService
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await Postgres.Migrate();
            await CreateHostBuilder(args).Build().RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}