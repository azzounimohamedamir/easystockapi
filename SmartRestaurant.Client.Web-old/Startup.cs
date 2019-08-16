using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Persistence.ApplicationDataBase;

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
            ConfigureInMemoryDataBases(services);
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
            services.AddDbContext<SmartRestaurantDbContext>(c =>
                c.UseInMemoryDatabase("SmartRestaurantDbInMemory"));

            //Add Identity DbContext
            //services.AddDbContext<AppIdentityDbContext>(options =>
            //    options.UseInMemoryDatabase("Identity"));

            ConfigureServices(services);
        }

        private void ConfigureSQLServerDatabases(IServiceCollection services)
        {
            services.AddDbContext<SmartRestaurantDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SmartRestaurantSqlConnection")));
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


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
                        
            app.UseMvc(routes =>
            {
                //Admin area
                routes.MapRoute(
                  name: "Admin",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
