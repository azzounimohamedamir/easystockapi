using SmartRestaurant.Application.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Identity
{
    public class LoginModel : ILoginModel
    {        
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
