using SmartRestaurant.Application.Identity;
using SmartRestaurant.Application.Users.Commands.Create;
using SmartRestaurant.Forms.Helpers;
using SmartRestaurant.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.Services
{
    public class LoginService : ILoginService
    {
        public APIHelper APIHelper { get; set; }
        public LoginService()
        {
            //var url = Device.RuntimePlatform == Device.Android ?
            //    "http://10.0.2.2:12064/api/account/register" : "http://192.168.1.10:12064/api/account/register";
            var url = "http://192.168.1.10:12064/api";
            APIHelper = new APIHelper(url);
        }
        public async Task<string> LoginAsync(LoginModel loginModel)
        {

            var url = "account/login";

            return await APIHelper.Post<string, LoginModel>(url, loginModel); 
  


        }

        public async Task<string> RegisterAsync(RegisterModel user)
        {
            var url = "account/register";
           return await APIHelper.Post<string, RegisterModel>(url, user);
        }


        public class CreateUserModel
        {
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}
