using SmartRestaurant.Domain.Common;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class Restaurant : AuditableEntity
    {
        /*
         * -  RestaurantId : Guid
-  RestaurantName : string
-  Address : string
-  Ville : string
-  PhoneNumber : string
-  Description : string
-  AverageRating : float
-  HasParking : bool
-  IsHandicapFriendly : bool
-  OffersTakeout : bool
-  AcceptsCreditCards : bool
-  AcceptTakeout : bool
-  GeoPosition : string
-  Tags : string
-  DefaultCurrency : string
-  DefaultLanguage : string
-  IsActive :  Enum
-  Website : string
-  NIS : string
-  NRC : string
-  NIF : string
-  ArticleNumber : string
         * */

        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }

        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public string Description { get; set; }
        public float AverageRating { get; set; }

        public bool HasCarParking { get; set; }
        public bool IsHandicapFreindly { get; set; }
        public bool OffersTakeout { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }

        public string Tags { get; set; }
        public string Website { get; set; }
       
    }
}
