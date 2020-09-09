using INFRASTUCTURE.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            #region Comments on using() 

            //any code running inside a using statement is disposed when done running
            //this is cos we are outside of the startup class wjere we do not have 
            //controll of the life time of the created instances. 
            //this is coz we are not depending on asp.net core to handle the disposation of such code lifetime

            #endregion

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                #region Comments on ILoggrFactory

                //this is to log information out in the console
                //loggerfactory allows us to create instances of the logger

                #endregion

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<StoreDbContext>();

                    //will create the database if it does not already exist
                    await context.Database.MigrateAsync();

                }catch(Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An Error Occured During Migraion");
                }
                
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
