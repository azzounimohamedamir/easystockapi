using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Persistence.DateTime;
using System.Collections.Generic;

namespace SmartRestaurant.Persistence.Mailing
{
    public class Mail : IMail
    {
        public Mail()
        {
            Date = new MachineDateTime();
            CCs = new HashSet<string>();
            Tos = new HashSet<string>();
        }
        public IEnumerable<string> CCs { get; set; }
        public IDateTime Date { get; set; }
        public NotificationType Type { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Tos { get; set; }
    }
}
