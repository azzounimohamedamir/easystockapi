using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Commun;
using SmartRestaurant.Client.Web.Hubs;
using SmartRestaurant.Client.Web.Utils;
using SmartRestaurant.Domain.BaseIdentity;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Domain.Identity.Guests;
using SmartRestaurant.Persistance.Identity;
using SmartRestaurant.Persistence.ApplicationDataBase;
using SmartRestaurant.Persistence.Logger;
using SmartRestaurant.Persistence.Mailing;
using SmartRestaurant.Persistence.Notifications;
using System;
using System.Globalization;

namespace SmartRestaurant.Client.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            //ConfigureInMemoryDataBases(services);
            ConfigureSQLServerDatabases(services);
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            ConfigureSQLServerDatabases(services);
            ConfigureServices(services);
        }

        private void ConfigureInMemoryDataBases(IServiceCollection services)
        {
            // use in-memory database
            //services.AddDbContext<SmartRestaurantDbContext>(c =>
            //    c.UseInMemoryDatabase("SmartRestaurantDbInMemory"));

            //Add Identity DbContext
            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseInMemoryDatabase("Identity"));

            ConfigureSQLServerDatabases(services);
            ConfigureServices(services);
        }

        private void ConfigureSQLServerDatabases(IServiceCollection services)
        {
            services.AddDbContext<SmartRestaurantDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantSqlConnection")));
            services.AddDbContext<SmartRestaurantTeamIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantTeamIdentityDbContext")));
            services.AddDbContext<SmartRestaurantGuestIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantGuestIdentityDbContext")));
            services.AddDbContext<SmartRestaurantIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantIdentityDbContext")));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("en-US"),
                    new CultureInfo("fr"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("ar"),
                    new CultureInfo("ar-DZ"),
                    new CultureInfo("es"),
                    new CultureInfo("es-ES")
                };

                options.DefaultRequestCulture = new RequestCulture(culture: "fr-FR", uiCulture: "fr-FR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new UrlRequestCultureProvider());

            });            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Injection des service Mailling,Notify et logger implémenté dans la couche infrastructure
            services.AddScoped<IMail, Mail>();
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<INotification, Notification>();
            services.AddScoped<INotifyService, NotifyService>();
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));

         
            services.AddSRServices();
            
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors();

            services.AddSignalR();
            services.AddMvc().AddFluentValidation();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            //Ajout de la validation pour les entities 
            //Fluent Validation implémenté dans la couche application
            services.AddSREntitiesFluentValidation();
            try {

               // services.AddIdentity<SRIdentityUser, SRIdentityRole>()
               //  .AddEntityFrameworkStores<SmartRestaurantIdentityDbContext>()
               //  .AddDefaultTokenProviders();                


               // services.AddIdentityCore<SRIdentityUser>().AddRoles<SRIdentityRole>()
               // .AddEntityFrameworkStores<SmartRestaurantIdentityDbContext>()
               // .AddDefaultTokenProviders();

               // services.AddIdentity<GuestIdentityUser, GuestIdentityRole>()
               //  .AddEntityFrameworkStores<SmartRestaurantGuestIdentityDbContext>()
               //  .AddDefaultTokenProviders();

               // services.AddIdentityCore<GuestIdentityUser>().AddRoles<GuestIdentityRole>()
               // .AddEntityFrameworkStores<SmartRestaurantGuestIdentityDbContext>()
               // .AddDefaultTokenProviders();

             // services.AddIdentityCore<SRIdentityUser>().AddRoles<SRIdentityRole>()
            //.AddEntityFrameworkStores<SmartRestaurantIdentityDbContext>()
            //.AddDefaultTokenProviders();

            //services.AddIdentity<GuestIdentityUser, GuestIdentityRole>()
            //    .AddEntityFrameworkStores<SmartRestaurantGuestIdentityDbContext>()
            //     .AddDefaultTokenProviders();
            //;

              //  services.AddIdentityCore<GuestIdentityUser>().AddRoles<GuestIdentityRole>()
           //.AddEntityFrameworkStores<SmartRestaurantGuestIdentityDbContext>()
           //.AddDefaultTokenProviders();

            //    services.AddIdentity<BaseIdentityUser, BaseIdentityRole>()
            // .AddEntityFrameworkStores<SmartRestaurantTeamIdentityDbContext>()
            //  .AddDefaultTokenProviders();
            //;
               // services.AddIdentityCore<BaseIdentityUser>().AddRoles<BaseIdentityRole>()
                 //      .AddEntityFrameworkStores<SmartRestaurantTeamIdentityDbContext>()
                   //    .AddDefaultTokenProviders();

            }
            catch
            {
                

            }
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRequestLocalization();
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            //localizationOptions.RequestCultureProviders.Insert(0, new UrlRequestCultureProvider());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSignalR(routes => { routes.MapHub<OrderHub>("/restaurants/ordershub"); });

            //app.UseSignalR(routes => routes.MapHub<OrderHub>("/restaurants/ordershub"));
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                //routes.MapAreaRoute(
                //    name: "AreaClientsWithRestaurantWithCulture",
                //    areaName: "Clients",
                //    template: "{culture}/{restaurant}/{controller=Home}/{action=Index}/{id?}");

                //routes.MapAreaRoute(
                //    name: "AreaClientsWithRestaurant",
                //    areaName: "Clients",
                //    template: "{restaurant}/{controller=Home}/{action=Index}/{id?}");

                //routes.MapAreaRoute(
                //   name: "AreaClientsWithRestaurant",
                //   areaName: "Clients",
                //   template: "{restaurant}/{controller=Home}/{action=Index}/{id?}");

                //routes.MapAreaRoute(
                //    name: "AreaClients",
                //    areaName: "Clients",
                //    template: "Clients/{controller=Home}/{action=Index}/{id?}");



                //routes.MapAreaRoute(
                //    name: "AreaAdmin",
                //    areaName: "Admin",
                //    template: "Admin/{controller=Home}/{action=Index}/{id?}");

                //routes.MapAreaRoute(
                //    name: "AreaGuest",
                //    areaName: "Guest",
                //    template: "Guest/{controller=Home}/{action=Index}/{id?}");
               

                routes.MapAreaRoute(
                   name: "AreaTranslate",
                   areaName: "Translate",
                   template: "Translate/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "AreaAdmin",
                    areaName: "Admin",
                    template: "Admin/{controller=Home}/{action=Index}/{id?}");
                    //areaName: "Clients",
                    //name: "Clients_RestaurantDetails",
                    //template: "Clients/{restaurant?}/details",
                    //defaults: new { controller = "Restaurants", action = "details" }
                //);

                routes.MapAreaRoute(
                    areaName: "Clients",
                    name: "ClientsWithRestaurant",
                    template: "Clients/{restaurant?}/{controller}/{action}/{id?}"
                    //defaults: new { controller = "Home", action = "Index" }
                );

                routes.MapAreaRoute(
                    areaName: "Clients",
                    name: "ClientsDefault",
                    template: "{controller}/{action}/{id?}"
                    //defaults: new { controller = "Home", action = "Index" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });

            app.UseCors(cors =>
            {
                cors.AllowAnyHeader();
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
            });

            app.UseWebSockets();

        }
    }
}
