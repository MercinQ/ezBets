using ezBet.Daemon;
using NLog;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Daemon
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            _logger.Info("Version: " + Assembly.GetEntryAssembly().GetName().Version.ToString());
            var hostedService = new HostedService();
            hostedService.Run(args);

            _logger.Info("Shutting down logger...");
            // Flush buffered log entries before program exit; then shutdown the logger before program exit.
            LogManager.Flush(TimeSpan.FromSeconds(15));
            LogManager.Shutdown();
        }
    }
}
