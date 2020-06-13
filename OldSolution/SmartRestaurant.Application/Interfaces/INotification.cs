using System.Collections.Generic;

namespace SmartRestaurant.Application.Interfaces
{
    public interface INotification
    {
        IDateTime Date { get; set; }
        NotificationType Type { get; set; }
        string Title { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        IEnumerable<string> Tos { get; set; }
    }
    public enum NotificationType
    {
        Error=3,
        Warning=2,
        Success=1,
        Infos=4
    }
}

