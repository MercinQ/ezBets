using ezBet.WebAPI.Model;
using entities = ezBet.WebAPI.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace ezBet.Daemon
{
    public class PasswordResetService : IHostedService
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Task _executingTask;

        private ILogger<PasswordResetService> _logger;
        private EzBetDbContext _dbContext;
        private IConfiguration _configuration;

        public PasswordResetService(
            IConfiguration configuration,
            ILogger<PasswordResetService> logger,
            EzBetDbContext dbContext)
        {
            _configuration = configuration;
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogTrace("PasswordResetService - StartAsync method called.");
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _executingTask = Run(_cancellationTokenSource.Token);
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogTrace("PasswordResetService - StopAsync method called.");

            // Stop called without start
            if (_executingTask == null)
            {
                return;
            }

            // stop service processes here
            _cancellationTokenSource.Cancel();
            _logger.LogInformation("PasswordResetService - Stopped.");

            // Wait until the task completes or the stop token triggers
            await Task.WhenAny(_executingTask, Task.Delay(-1, cancellationToken));
        }

        private async Task Run(CancellationToken cancellationToken)
        {
            _logger.LogTrace("Starting job...");

            await Task.Delay(TimeSpan.FromMilliseconds(500), cancellationToken);
          
            while (!cancellationToken.IsCancellationRequested)
            {                               
                DoJob();                
                await Task.Delay(TimeSpan.FromMilliseconds(1000), cancellationToken);
            }
        }

        public void DoJob()
        {
            try
            {
                var singleTask = _dbContext.Tasks.Where(x => x.State == entities.TaskState.New && x.Type == entities.TaskType.ResetPassword).FirstOrDefault();
                if (singleTask != null)
                {
                    //in reset-password task (info property will contain only email address)
                    var user = _dbContext.Users.FirstOrDefault(x => x.Email == singleTask.Info);
                    if (user != null)
                    {
                        user.ResetPasswordToken = Guid.NewGuid().ToString();
                        SendEmail(receiver: singleTask.Info, token: user.ResetPasswordToken);
                        singleTask.State = entities.TaskState.Closed;
                        _dbContext.SaveChanges();
                        _logger.LogInformation("Job Completed");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message);
            }

        }

        private void SendEmail(string receiver, string token)
        {
            var fromAddress = new MailAddress("essabet666@gmail.com");
            var toAddress = new MailAddress(receiver);
            const string fromPassword = "ZAPYTAJ MARCINA";
            const string subject = "reset_password";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = $"https://localhost:44399/api/resetpassword/token/{token}"  //link do angulara
            })
            {
                smtp.Send(message);
            }
        }
    }
}
