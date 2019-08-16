using SmartRestaurant.Domain.Commun;
using System;

namespace SmartRestaurant.Domain.Services
{
    public enum TypeStatus
    {
        Finished,
        InProcess,
        Waiting,
    }

    public class ServiceState
    {        
        public Guid ServiceId { get; set; }
        public TypeStatus State { get; set; }

        public DateTime SysDate { get; set; }
        public Service Service { get; set; }
    }
}