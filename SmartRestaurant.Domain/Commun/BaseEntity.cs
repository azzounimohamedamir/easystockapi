using System;
using System.Collections.Generic;
using System.Text;
using Helpers;

namespace SmartRestaurant.Domain.Commun
{    
    //Level 1
    public class SmartRestaurantEntity
    {
        public bool IsDisabled { get; set; }
    }
    //Level 2
    public class SmartRestaurantBaseEntity<TId>: SmartRestaurantEntity
    {
        public TId Id { get; set; }
        public string Alias { get; set; }//Country:dz
    }
    //Alias
    //King TWIN Single Double... KNG TWI
    //Level 3
    public class BaseEntity<TId>: SmartRestaurantBaseEntity<TId>
    {
        private string _name;
        public string Name {
            get {
                return _name;
            }
            set {
                _name = value;
                //name="s'est arrêté avec le code"
                //SlugUrl="s-est-arrete-avec-le-code"
                SlugUrl = _name.ToSlugUrl();
            }
        }
        public string Description { get; set; }
        public string SlugUrl { get; set; }        
    }
}
