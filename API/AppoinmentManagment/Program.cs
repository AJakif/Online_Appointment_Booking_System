using Microsoft.AspNetCore.Hosting;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppoinmentManagment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .WriteTo.File("logs/log.txt",
               restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
               rollingInterval: RollingInterval.Day)
               .CreateLogger();
            try
            {
                Log.Information("Starting our service..");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Exception in application..");
            }
            finally
            {
                Log.Information("Exiting service");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
