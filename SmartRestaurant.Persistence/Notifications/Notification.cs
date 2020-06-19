using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Persistence.DateTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistence.Notifications
{
    public class Notification : INotification
    {
        public Notification()
        {
            Date = new MachineDateTime();            
            Tos = new HashSet<string>();
        }
        public IDateTime Date { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Tos { get; set; }
    }
}
