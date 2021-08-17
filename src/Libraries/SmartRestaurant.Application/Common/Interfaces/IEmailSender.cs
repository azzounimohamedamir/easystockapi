using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        void SendEmail(string email, string subject, string message);
    }
}