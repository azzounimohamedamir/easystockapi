using AutoMapper;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartRestaurant.API.Configurations;
using SmartRestaurant.Application;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Email;
using SmartRestaurant.Infrastructure;
using SmartRestaurant.Infrastructure.Identity;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace SmartRestaurant.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddDirectoryBrowser();
            services.AddInfrastructure(Configuration);
            services.AddIdentityInfrastructure(Configuration);
            services.AddMemoryCache();
            services.AddHttpContextAccessor();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddAutoMapper(typeof(MappingProfile));
            services.Configure<SmtpConfig>(Configuration.GetSection("Smtp"));
            CORSConfiguration.AddCORSConfiguation(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Smart Restaurant api v1", Version = "v1"});              
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.EnableAnnotations();


                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {{ new OpenApiSecurityScheme {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }});
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
              

                c.ExampleFilters();
                c.OperationFilter<AddResponseHeadersFilter>();


                c.AddFluentValidationRules();
            });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddControllersWithViews()
             .AddFluentValidation(c => {
                 c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
             })
             .AddJsonOptions(options => {
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
             });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            CORSConfiguration.UseCORS(app, env);

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Restaurant api v1");
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}