using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using SmartRestaurant.Application.Common.Interfaces;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Tools
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
        private readonly SmtpConfig _smtpConfig;
        public EmailHelper(SmtpConfig smtpConfig)
        {
            _smtpConfig = smtpConfig;
        }
        public void SendEmail(string userEmail, string subject, string emailContent)
        {
            var message = new MimeMessage();
            message.To.Add(new MailboxAddress("", userEmail));
            message.From.Add(new MailboxAddress("", _smtpConfig.Email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html) { Text = emailContent };

            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect(_smtpConfig.Server, _smtpConfig.Port, false);
                emailClient.Authenticate(_smtpConfig.Email, _smtpConfig.Pass);
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }      
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
