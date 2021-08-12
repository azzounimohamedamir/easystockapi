using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class FoodBusinessEmployees
    {

        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public string PhoneNumber { get; set; }
        public bool isActive { get; set; }
        public Guid FoodBusinessId { get; set; }
        public Guid FoodBusinessName { get; set; }
    }
}