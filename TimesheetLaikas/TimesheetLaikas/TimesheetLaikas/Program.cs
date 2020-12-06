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
using Serilog.Core;
using TimesheetLaikas.Data;

namespace TimesheetLaikas
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var host = CreateWebHostBuilder(args).Build();
            using (var log = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger())
            {
                log.Information("Hello, Serilog!");
                log.Warning("Goodbye, Serilog.");
            }
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

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
                WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging((ctx, builder)=>
            {
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
                //ctx.ClearProviders();
                //ctx.AddConsole();
>>>>>>> parent of 7d84655... Revert "Merge branch 'main' of https://github.com/DonatelloLTU/Laikas into main"
=======
                //ctx.ClearProviders();
                //ctx.AddConsole();
>>>>>>> parent of 7d84655... Revert "Merge branch 'main' of https://github.com/DonatelloLTU/Laikas into main"
=======
                //ctx.ClearProviders();
                //ctx.AddConsole();
>>>>>>> parent of 7d84655... Revert "Merge branch 'main' of https://github.com/DonatelloLTU/Laikas into main"
                builder.AddConfiguration(
              ctx.Configuration.GetSection("Logging"));
                builder.AddConsole();
            })
                    .UseSerilog()
                    .UseStartup<Startup>();
    }
}