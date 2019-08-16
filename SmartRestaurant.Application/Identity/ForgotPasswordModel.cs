using SmartRestaurant.Application.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Identity
{
    public class ForgotPasswordModel : IForgotPasswordModel
    {
        public string Email { get; set; }
    }
}
