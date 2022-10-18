using Microsoft.Extensions.Options;
using MimeKit.Text;
using MimeKit;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace SmartRestaurant.Infrastructure.Email
{
    public class SmtpConfig
    {
        public string Server { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public int Port { get; set; }
    }
    public class EmailHelper : IEmailSender
    {


        private readonly IOptions<SmtpConfig> _smtpConfig;

        public EmailHelper(IOptions<SmtpConfig> smtpConfig)
        {
            _smtpConfig = smtpConfig;
        }

        public void SendEmail(string userEmail, string subject, string emailContent)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("", userEmail));
            message.From.Add(new MailboxAddress("", _smtpConfig.Value.Email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = emailContent };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_smtpConfig.Value.Server, _smtpConfig.Value.Port, false);
                emailClient.Authenticate(_smtpConfig.Value.Email, _smtpConfig.Value.Pass);
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }
    }
}
