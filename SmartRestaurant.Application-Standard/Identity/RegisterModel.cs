using SmartRestaurant.Application.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Identity
{
    public class RegisterModel :LoginModel, IRegisterModel
    {        
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PasswordConfirmation { get; set; }
    }
}
