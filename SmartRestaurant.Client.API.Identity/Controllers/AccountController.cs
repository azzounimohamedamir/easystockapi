using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SmartRestaurant.Application.Identity;
using SmartRestaurant.Application.Identity.Interfaces;
using SmartRestaurant.Domain.BaseIdentity;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Identity.Guests;

namespace SmartRestaurant.Client.API.Identity.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        readonly UserManager<SRIdentityUser> userManager;
        readonly SignInManager<SRIdentityUser> signInManager;
        private readonly SignInManager<BaseIdentityUser> teamsignInManager;
        private readonly SignInManager<GuestIdentityUser> guestsignInManager;
        private readonly UserManager<GuestIdentityUser> guestManager;
        private readonly UserManager<BaseIdentityUser> baseManager;
        readonly IConfiguration configuration;
        readonly ILogger<AccountController> logger;

        public AccountController(
           UserManager<SRIdentityUser> userManager,
           SignInManager<SRIdentityUser> signInManager,
           SignInManager<BaseIdentityUser> TeamsignInManager,
           SignInManager<GuestIdentityUser> GuestsignInManager,
           UserManager<GuestIdentityUser> guestManager,
           UserManager<BaseIdentityUser> baseManager,
           IConfiguration configuration,
           ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.teamsignInManager = TeamsignInManager;
            this.guestsignInManager = GuestsignInManager;
            this.guestManager = guestManager;
            this.baseManager = baseManager;
            this.configuration = configuration;
            this.logger = logger;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> CreateToken([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager
                                        .PasswordSignInAsync(
                                        loginModel.Username,
                                        loginModel.Password,
                                        isPersistent: false,
                                        lockoutOnFailure: false);

                if (!loginResult.Succeeded)
                {
                    return BadRequest();
                }

                var user = await userManager.FindByNameAsync(loginModel.Username);
                return Ok(GetToken(user));
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken()
        {            
            var user = await userManager.FindByNameAsync(
                User.Identity.Name ??
                User.Claims.Where(
                    c => c.Properties.ContainsKey("unique_name"))
                    .Select(c => c.Value).FirstOrDefault()
                );
            return Ok(GetToken(user));

        }


        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<string> Register([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                //TODO:Reapatative Code must undone 
                IdentityResult identityResult;
                if (registerModel.RoleName == "Guest")
                {
         
                    var guest = new GuestIdentityUser
                    {
                         
                        UserName = registerModel.Username,
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        Email = registerModel.Email
                    };
                 identityResult = await this.guestManager.CreateAsync(guest, registerModel.Password);
                    if (identityResult.Succeeded)
                    {
                        await this.guestManager.AddClaimAsync(guest, new Claim("organisation", "g22r"));
                        await this.guestManager.AddClaimAsync(guest, new Claim("restaurantId", "restaurantId"));
                        await this.guestManager.AddClaimAsync(guest, new Claim("isDisabled", "isDisabled"));
                        await this.guestManager.AddClaimAsync(guest, new Claim("unique_name", guest.UserName));
                        await this.guestManager.AddClaimAsync(guest, new Claim("family_name", guest.FirstName));
                        await this.guestManager.AddClaimAsync(guest, new Claim("last_name", guest.LastName));
                        await this.guestManager.AddClaimAsync(guest, new Claim("gender", "1"));
                        await this.guestManager.AddClaimAsync(guest, new Claim("email", guest.Email));
                        await this.guestManager.AddClaimAsync(guest, new Claim("id", guest.Id));
                        
                        //await this.guestManager.AddToRoleAsync(guest, registerModel.RoleName);
                        await guestsignInManager.SignInAsync(guest, isPersistent: false);
                        return GetToken(guest);

                    }
                    else
                    {
                        return null;

                    }

                }
                else if(registerModel.RoleName == "Developper")
                {
                    var team = new BaseIdentityUser
                    {
                        //TODO: Use Automapper instaed of manual binding 
                        UserName = registerModel.Username,
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        Email = registerModel.Email
                    };
                    identityResult = await this.baseManager.CreateAsync(team, registerModel.Password);
                    if (identityResult.Succeeded)
                    {
                        await this.baseManager.AddClaimAsync(team, new Claim("organisation", "g22r"));
                        await this.baseManager.AddClaimAsync(team, new Claim("restaurantId", "restaurantId"));
                        await this.baseManager.AddClaimAsync(team, new Claim("isDisabled", "isDisabled"));
                        await this.baseManager.AddClaimAsync(team, new Claim("unique_name", team.UserName));
                        await this.baseManager.AddClaimAsync(team, new Claim("family_name", team.FirstName));
                        await this.baseManager.AddClaimAsync(team, new Claim("last_name", team.LastName));
                        await this.baseManager.AddClaimAsync(team, new Claim("gender", "1"));
                        await this.baseManager.AddClaimAsync(team, new Claim("email", team.Email));
                        await this.baseManager.AddClaimAsync(team, new Claim("id", team.Id));
                        //await this.baseManager.AddToRoleAsync(team, registerModel.RoleName);
                        await teamsignInManager.SignInAsync(team, isPersistent: false);
                        return GetToken(team);

                    }
                    else
                    {
                        return null;

                    }





                }
                else
                {
                    var user = new SRIdentityUser
                    {
                        //TODO: Use Automapper instaed of manual binding 
                        UserName = registerModel.Username,
                        FirstName = registerModel.FirstName,
                        LastName = registerModel.LastName,
                        Email = registerModel.Email
                    };

                 identityResult = await this.userManager.CreateAsync(user, registerModel.Password);
                    if (identityResult.Succeeded)
                    {
                        await this.userManager.AddClaimAsync(user, new Claim("organisation", "g22r"));
                        await this.userManager.AddClaimAsync(user, new Claim("restaurantId", "restaurantId"));
                        await this.userManager.AddClaimAsync(user, new Claim("isDisabled", "isDisabled"));
                        await this.userManager.AddClaimAsync(user, new Claim("unique_name", user.UserName));
                        await this.userManager.AddClaimAsync(user, new Claim("family_name", user.FirstName));
                        await this.userManager.AddClaimAsync(user, new Claim("last_name", user.LastName));
                        await this.userManager.AddClaimAsync(user, new Claim("gender", "1"));
                        await this.userManager.AddClaimAsync(user, new Claim("email", user.Email));
                        await this.userManager.AddClaimAsync(user, new Claim("id", user.Id));
                        await this.userManager.AddToRoleAsync(user, registerModel.RoleName);
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return GetToken(user);

                    } else
                {
                    return null;
                  
                }



              
             
                }
               
            }
            return null ;
        }

        private String GetToken(IdentityUser user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new Claim[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<String>("Tokens:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(this.configuration.GetValue<int>("Tokens:Lifetime")),
                audience: this.configuration.GetValue<String>("Tokens:Audience"),
                issuer: this.configuration.GetValue<String>("Tokens:Issuer")
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<string> Login([FromBody] LoginModel loginModel)
        {

            /// that in case of guest login 
            /// Case xamarin ---> Api
            /// must considerate my implementation to other roles logins 
            if (ModelState.IsValid)
            {
                var user = await this.guestManager.FindByNameAsync(loginModel.Username);
                if (user == null)
                {
                    return null; 

                } 

                var UserhasValidPass = await guestManager.CheckPasswordAsync(user, loginModel.Password);
                    if (!UserhasValidPass)
                {
                    return null;



                }
                 
                    return GetToken(user);

            }
            return null;
        }


        //[HttpPost]
        //[AllowAnonymous]
        //[Route("ForgotPassword")]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await userManager.FindByNameAsync(model.Email);
        //        // If user has to activate his email to confirm his account, the use code listing below
        //        //if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
        //        //{
        //        //    return Ok();
        //        //}
        //        if (user == null)
        //        {
        //            return Ok();
        //        }

        //        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //        // Send an email with this link
        //        string code = await userManager.GeneratePasswordResetTokenAsync(user.Id);
        //        await userManager.SendEmailAsync(user.Id, "Reset Password", $"Please reset your password by using this {code}");
        //        return Ok();
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return BadRequest(ModelState);
        //}



    }
}