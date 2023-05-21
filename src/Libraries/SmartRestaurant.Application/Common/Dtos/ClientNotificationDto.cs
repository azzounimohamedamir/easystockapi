using SmartRestaurant.Application.Common.Enums;
using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ClientNotificationDto
    {
        public ClientNotificationType Type { get; set; }
        public string Message { get; set; }
        public bool Read { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ParentId { get; set;}
        public string ChildId { get; set;}

    }
}
