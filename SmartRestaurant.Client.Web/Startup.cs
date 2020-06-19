using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Client.Commun;
using SmartRestaurant.Client.Web.Hubs;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Persistance.Identity;
using SmartRestaurant.Persistence;
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
        public const string CookieScheme = "SR.Application";
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            //ConfigureInMemoryDataBases(services);
            ConfigureSqlServerDatabases(services);
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            ConfigureSqlServerDatabases(services);
            ConfigureServices(services);
        }

        private void ConfigureInMemoryDataBases(IServiceCollection services)
        {

            ConfigureSqlServerDatabases(services);
            ConfigureServices(services);
        }

        private void ConfigureSqlServerDatabases(IServiceCollection services)
        {
            string assemblyName = typeof(SmartRestaurantDbContext).Namespace;

            services.AddDbContext<SmartRestaurantDbContext>(
                c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantSqlConnection"), x => x.MigrationsAssembly(assemblyName)));
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdministratorRole",
                    policy => policy.RequireRole("Owner", "Developer", "Admin"));
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


            //Injection des service Mailling,Notify et logger implémenté dans la couche infrastructure
            services.AddScoped<IMail, Mail>();
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<INotification, Notification>();
            services.AddScoped<INotifyService, NotifyService>();
            services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));


            services.AddSRServices();

            services.AddSingleton(Configuration);
            services.AddCors();

            services.AddSignalR();
            services.AddMvc().AddFluentValidation();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            //Ajout de la validation pour les entities 
            //Fluent Validation implémenté dans la couche application
            services.AddSREntitiesFluentValidation();
            services.AddIdentity<SRIdentityUser, SRIdentityRole>()
                .AddEntityFrameworkStores<SmartRestaurantIdentityDbContext>()
                .AddDefaultTokenProviders();
            var appSettingsSection = Configuration.GetSection("ConnectionStrings");
            services.Configure<AppSettings>(appSettingsSection);
            services.AddSingleton(appSettingsSection);
            services.ConfigureApplicationCookie(options =>
            {
                //options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "SR";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";

                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRequestLocalization();
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

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
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            //  app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                   name: "AreaTranslate",
                   areaName: "Translate",
                   template: "Translate/{controller=Home}/{action=Index}/{id?}");


                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=home}/{action=index}/{id?}");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseCors(cors =>
            {
                cors.AllowAnyHeader();
                cors.AllowAnyOrigin();
                cors.AllowAnyMethod();
            });


            app.UseWebSockets();
            app.UseMvc();

            SeedInitialData(app);


        }

        private static void SeedInitialData(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                #region seed identity data

                var identityContext = scope.ServiceProvider.GetService<SmartRestaurantIdentityDbContext>();
                var identitySeed = new SmartRestaurantIdentitySeed(identityContext);

                if (!identityContext.Roles.Any())
                {
                    identitySeed.CreateRoles(scope.ServiceProvider).GetAwaiter().GetResult();
                    identitySeed.CreateDummyUser(scope.ServiceProvider).GetAwaiter().GetResult();
                }


                #endregion

                #region seed restaurant data

                var context = scope.ServiceProvider.GetService<SmartRestaurantDbContext>();
                var seed = new SmartRestaurantDatabaseSeed(context);
                if (!context.Languages.Any())
                {
                    seed.ClearAllDataAsync().Wait();
                    seed.SeedEverythingAsync().Wait();
                }


                #endregion


                // do you things here
            }
        }
    }
}
