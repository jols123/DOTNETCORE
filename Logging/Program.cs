using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logger = host.Services.GetRequiredService<ILogger<Program>>();   // use dependency injection 
            logger.LogInformation("The application has started");
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureLogging((context,logging)=>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging")); //referring to logging in appsettings.json
                    //logging.AddDebug();  //locahost :5001 - we just want console not debugger so comment it.
                    logging.AddConsole();  
                    //EventSource.Eventlog (Warn, debug, info, critical events). TraceSource. AzureAppServicesFile, AzureAppServicesBlog,ApplicationInsights
                    //runs synchronously.
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        }
    }
}
