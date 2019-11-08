using SmartRestaurant.Application.Identity;
using SmartRestaurant.Forms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static SmartRestaurant.Forms.Services.LoginService;

namespace SmartRestaurant.Forms.Interfaces
{
    public interface ILoginService
    {
        Task<string> LoginAsync(LoginModel loginModel);
        Task<string> RegisterAsync(RegisterModel user);
    }
}
