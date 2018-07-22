using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Project.DistributedService.WebHostCore
{
    public class Program
    {
        public static void Main(string[] args) => BuildWebHost(args).Run();
        public static bool DisableProfilingResults { get; internal set; }

        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;

                    var sharedFolder = Path.Combine(env.ContentRootPath, "Shared");

                    config
                        .AddJsonFile(Path.Combine(sharedFolder, "shared_settings.json"), optional: true) // When running using dotnet run
                        .AddJsonFile("appsettings.json", optional: true) // When app is published
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);// // When app is developing

                    config.AddEnvironmentVariables();
                })
                .ConfigureLogging((ctx, log) => { /* elided for brevity */ })
                .UseDefaultServiceProvider((ctx, opts) => { /* elided for brevity */ })
                .UseStartup<Startup>()
                .Build();
    }
}
