using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;

using Microsoft.TeamFoundation.Test.WebApi;
using MimeKit;
using MailKit.Net.Smtp;

using WebApplicationEMPTY.GetWeather;

namespace WebApplicationEMPTY.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        
        private readonly ILogger<TimedHostedService> _logger;
        private Timer? _timer = null;
        private string message = $"<table> <thead><tr><th>temp</th><th>city</th><th></th></tr></thead> <tbody>\r\n\r\n        \r\n        <tr>\r\n\r\n            <td>{getweather.WeatherGet().main.temp}</td>\r\n            <td>{getweather.WeatherGet().name}</td>\r\n        </tr>\r\n        \r\n        </tbody>\r\n    </table> ";
        public static GetWeather.GetWeather getweather = new GetWeather.GetWeather();
        static bool sent = false;
        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }
        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(SendMailWeather, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void SendMailWeather(object? state)
        {
            DateTime dd = DateTime.Now;
            if (dd.Hour == 11 && dd.Minute == 45 && sent == false)
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress("Admin Matvey", "matveykka@gmail.com"));
                emailMessage.To.Add(new MailboxAddress("", "izmailoffmatvei@yandex.ru"));
                emailMessage.Subject = "test";
                emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = message
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("matveykka@gmail.com", "sulc iiuo ymfb guaa");
                    client.Send(emailMessage);
                }
                sent = true;
                _logger.LogInformation(
                    "SendService send Email");
            }
            else if (dd.Hour != 11 && dd.Minute != 45)
            {
                sent = false;
            }


            _logger.LogInformation(
                "Timed Hosted Service is working");
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
