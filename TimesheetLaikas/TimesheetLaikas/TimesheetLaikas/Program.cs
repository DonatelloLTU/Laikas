using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Serilog.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Formatting.Compact;
using TimesheetLaikas.Data;
using Microsoft.AspNetCore;
namespace TimesheetLaikas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var appSettings = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var logDB = @"Server=...";
            var sinkOpts = new MSSqlServerSinkOptions { TableName = "Logs" };
            var columnOpts = new ColumnOptions();

            var log = new LoggerConfiguration()
                .WriteTo.MSSqlServer(
                    connectionString: logDB,
                    sinkOptions: sinkOpts,
                    columnOptions: columnOpts,
                    appConfiguration: appSettings
                ).CreateLogger();
            var itemCount = 99;
            for (var itemNumber = 0; itemNumber < itemCount; ++itemNumber)
                Log.Debug("Processing item {ItemNumber} of {ItemCount}", itemNumber, itemCount);

            Log.CloseAndFlush();
            try
                {
                BuildWebHost(args).Run();
                }
                catch (Exception ex)
                {

                Log.Fatal(ex, "Host terminated unexpectedly");
                }
                finally
                {
                AppDomain.CurrentDomain.ProcessExit += (s, e) => Log.CloseAndFlush();
                }
            }
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();

        public static IWebHost BuildWebHost(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
          .ConfigureLogging((builder) =>
        {
            builder.AddSerilog();
        })
                    
                    .UseSerilog()
                    .UseStartup<Startup>()
                    .Build();
    }
}