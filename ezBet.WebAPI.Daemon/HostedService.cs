using System;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog.Extensions.Hosting;
using NLog;
using ezBet.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace ezBet.Daemon
{
   public class HostedService
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        IConfiguration Configuration { get; }

        public void Run(string[] args)
        {
            try
            {
                var builder = new HostBuilder().UseNLog()
                    .ConfigureAppConfiguration((hostingContext, config) =>
                    {
                        config.SetBasePath(Directory.GetCurrentDirectory());
                        config.AddJsonFile("appsettings.json", optional: true);
                        config.AddCommandLine(args);
                    })
              .ConfigureServices((hostContext, services) =>
              {
                  services.AddHostedService<PasswordResetService>();
                  services.AddEntityFrameworkNpgsql().AddDbContext<EzBetDbContext>(opt => opt.UseNpgsql("Host=localhost;Database=ez_bet;Username=postgres;Password=test", b => b.MigrationsAssembly("ezBet.WebAPI.Model")));                
                  services.Configure<HostOptions>(option =>
                  {
                      option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
                  });
              })
              .ConfigureLogging((hostingContext, logging) =>
              {
                  logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                  logging.AddConsole();
              });

                builder.Build().Run();               
            }
            catch (Exception ex)
            {
                _logger.Error("Could not start as Linux daemon service. " + ex.Message);
            }

        }
    }
}
