using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Notifications
{
    public class Notification : SmartRestaurantBaseEntity<Guid>
    {
        public NotificationTemplate Template { get; set; }
        /// <summary>
        /// Date d'enregistrement sur le systeme
        /// </summary>
        public DateTime SysDate { get; set; }

    }
}
