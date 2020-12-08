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
using Serilog.Formatting.Compact;
using Serilog.Core;
using TimesheetLaikas.Data;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;

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
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
    {
        new SqlColumn
            {ColumnName = "EnvironmentUserName", PropertyName = "UserName", DataType = SqlDbType.NVarChar, DataLength = 64},

        new SqlColumn
            {ColumnName = "UserId", DataType = SqlDbType.BigInt, NonClusteredIndex = true},

        new SqlColumn
            {ColumnName = "RequestUri", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = false},
    }
            };

            var log = new LoggerConfiguration()
                .WriteTo.MSSqlServer(@"Server=...",
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "Timesheet" },
                    columnOptions: columnOptions)
                .CreateLogger();

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

                builder.AddConfiguration(
              ctx.Configuration.GetSection("Logging"));
                builder.AddConsole();
                builder.AddSerilog();
            })
                    .UseSerilog()
                    .UseStartup<Startup>();
    }
}