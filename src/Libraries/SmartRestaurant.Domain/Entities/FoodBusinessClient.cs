using SmartRestaurant.Domain.Common;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class FoodBusinessClient : Entreprise
    {
        public Guid FoodBusinessClientId { get; set; }
        public string ManagerId { get; set; }
        public Boolean Archived { get; set; }
        public Guid FoodBusinessId { get; set; }
        public FoodBusiness FoodBusiness { get; set; }
    }
}
