using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Commun
{
    public class Contact:SmartRestaurantBaseEntity<Guid>
    {        
        public EnumContactType Type { get; private set; }
        /// <summary>
        /// if Type=SocialNetwork then Issuer Facebook,google,wk ...for example
        /// </summary>
        public string Issuer { get; set; }
        public string Value { get; set; }

        //private Contact() { }

        public Contact(EnumContactType type,string value,string issuer)
        {
            Type = type;
            Value = value;
            Issuer = issuer;
        }

        public Restaurant Restaurant { get; set; }
        public Staff Staff { get; set; }

        //Suite au modifications proposées par M Okba Kadi
        public Owner Owner { get; set; }

        public Guid? RestaurantId { get; set; }
        public Guid? StaffId { get; set; }
        public Guid? OwnerId { get; set; }
    }
}
