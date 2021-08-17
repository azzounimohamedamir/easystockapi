using SmartRestaurant.Application.Common.Interfaces;
using System.Net.Mail;
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
            using (var mailMessage = new  MailMessage())
            using (var client = new  SmtpClient())
            {  
                mailMessage.From = new MailAddress(_smtpConfig.Email);
                mailMessage.To.Add(new MailAddress(userEmail));
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.Body = emailContent;

                client.Credentials = new System.Net.NetworkCredential(_smtpConfig.Email, _smtpConfig.Pass);
                client.Host = _smtpConfig.Server;
                client.Port = _smtpConfig.Port;
                client.Send(mailMessage);
            }        
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
