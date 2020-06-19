using SmartRestaurant.Domain.Enumerations;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Interfaces
{
    public interface IMailingService
    {
        //void Send(IMail mail);
        Task SendAsync(params string[] args);
        Task SendAsync(EnumAction action, string tableName);
    }

}
