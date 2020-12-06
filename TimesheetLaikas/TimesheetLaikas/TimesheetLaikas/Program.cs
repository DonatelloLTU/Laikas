using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Formatting.Compact;
using Serilog.Core;
using TimesheetLaikas.Data;

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
            var host = CreateWebHostBuilder(args).Build();
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

            Log.CloseAndFlush();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    SeedData.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
                finally
                {
                    Log.CloseAndFlush();
                }
            }

            host.Run();
        }
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .Build();
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((ctx, builder)=>
            {
<<<<<<< HEAD
=======
                //ctx.ClearProviders();
                //ctx.AddConsole();
>>>>>>> parent of 7d84655... Revert "Merge branch 'main' of https://github.com/DonatelloLTU/Laikas into main"
                builder.AddConfiguration(
              ctx.Configuration.GetSection("Logging"));
                builder.AddConsole();
                builder.AddSerilog();
            })
                    .UseSerilog()
                    .UseStartup<Startup>();
    }
}