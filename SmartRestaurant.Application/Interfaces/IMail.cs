using System.Collections.Generic;

namespace SmartRestaurant.Application.Interfaces
{
    public interface IMail : INotification
    {
        IEnumerable<string> CCs { get; set; }
    }
}