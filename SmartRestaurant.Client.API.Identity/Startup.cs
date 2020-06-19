using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartRestaurant.Client.API.Identity.Extension;
using SmartRestaurant.Domain.BaseIdentity;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Identity.Guests;
using SmartRestaurant.Persistance.Identity;

namespace SmartRestaurant.Client.API.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Add CORS  
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));
            #endregion

            #region Add Entity Framework and Identity Framework  

            services.AddDbContext<SmartRestaurantIdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));
  services.AddDbContext<SmartRestaurantTeamIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantTeamIdentityDbContext")));
            services.AddDbContext<SmartRestaurantGuestIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantGuestIdentityDbContext")));

            try
            {
                services.AddIdentity<SRIdentityUser, SRIdentityRole>()
                      .AddEntityFrameworkStores<SmartRestaurantIdentityDbContext>();


                services.AddSecondIdentity<GuestIdentityUser, GuestIdentityRole>()
                    .AddEntityFrameworkStores<SmartRestaurantGuestIdentityDbContext>();

                services.AddSecondIdentity<BaseIdentityUser, BaseIdentityRole>()
                   .AddEntityFrameworkStores<SmartRestaurantTeamIdentityDbContext>();
            }
            catch (Exception ex )
            {

                throw ex ;
            }

           // services.AddIdentityCore<GuestIdentityUser>().AddRoles<GuestIdentityRole>()
           //.AddEntityFrameworkStores<SmartRestaurantGuestIdentityDbContext>()
           //.AddDefaultTokenProviders();

            
           //     services.AddIdentityCore<BaseIdentityUser>().AddRoles<BaseIdentityRole>()
           //            .AddEntityFrameworkStores<SmartRestaurantTeamIdentityDbContext>()
           //            .AddDefaultTokenProviders();
          
            #endregion

            #region Add Authentication  
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = true,
                    ValidAudience = this.Configuration["Tokens:Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = this.Configuration["Tokens:Issuer"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
            #endregion


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseCors("Cors");
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
