using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Restaurants
{
    public class Persone : SmartRestaurantBaseEntity<Guid>
    {        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;

        public DateTime DateOfBirth { get; set; }         
        public Address Address { get; set; }  

        public ICollection<Contact> Contacts{ get; set; }

        public string UserId { get; set; }
    }

    public class Staff: Persone
    {
        public EnumPersoneType StaffRole { get; set; }
        public Guid RestaurantId { get; set; }  
        public Restaurant Restaurant { get; set; }

        public ICollection<Menu> Menus { get; set; }
    }
}
