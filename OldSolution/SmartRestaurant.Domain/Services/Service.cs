using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Services
{
    public class Service:BaseEntity<Guid>
    {
        public Service()
        {
            ServiceStatus = new HashSet<ServiceState>();
            ServiceDishes = new HashSet<ServiceDish>();
            ServiceProducts = new HashSet<ServiceProduct>();
        }

        public EnumPeriode Periode { get; set; }
        public ServiceDateTime DateService { get; set; }

        public Guid RestaurantId { get; set; }

        public  ICollection<ServiceDish> ServiceDishes { get; set; }
        public  ICollection<ServiceProduct> ServiceProducts { get; set; }
        public  ICollection<ServiceState> ServiceStatus { get; set; }

        //Last ServiceStatus from ServiceStatus
        public ServiceState LastStatus { get; }
        public Restaurant Restaurant { get; set; }

        public bool Closed { get;}
    }
}
