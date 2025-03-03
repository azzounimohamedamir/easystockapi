﻿using SmartRestaurant.Domain.Identity.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.API.Models.UserModels
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; } 
        public string Password { get; set; }
        public List<string> Role {  get; set; }
    }
}