using AutoMapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartRestaurant.API.Configurations;
using SmartRestaurant.API.Scheduler;
using SmartRestaurant.API.Swagger;
using SmartRestaurant.Application;
using SmartRestaurant.Application.Common.Configuration;
using SmartRestaurant.Application.Common.Configuration.SocialMedia;
using SmartRestaurant.Application.Email;
using SmartRestaurant.Infrastructure;
using SmartRestaurant.Infrastructure.Email;
using SmartRestaurant.Infrastructure.Identity;
using SmartRestaurant.Infrastructure.Services;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using IHostApplicationLifetime = Microsoft.Extensions.Hosting.IHostApplicationLifetime;

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
            services.AddHttpContextAccessor();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddAutoMapper(typeof(MappingProfile));
            services.Configure<SmtpConfig>(Configuration.GetSection("Smtp"));
            services.Configure<WebPortal>(Configuration.GetSection("WebPortal"));
            services.Configure<EmailTemplates>(Configuration.GetSection("EmailTemplates"));
            services.Configure<Authentication>(Configuration.GetSection("Authentication"));
            //services.Configure<FirebaseConfig>(Configuration.GetSection("FirebaseConfig"));
            services.Configure<TranslationApiConfig>(Configuration.GetSection("TranslationApiConfig"));

            CORSConfiguration.AddCORSConfiguation(services);
            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap["string"] = typeof(AlphaRouteConstraint);
            });
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EASY STOCK api v1", Version = "v1" });
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
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                    c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();


                    c.ExampleFilters();
                    c.OperationFilter<AddResponseHeadersFilter>();
                    c.OperationFilter<AddRequiredHeaderParameter>();

                    c.AddFluentValidationRules();
                });
            services.AddSwaggerGenNewtonsoftSupport();
            services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

            services.AddControllersWithViews()
                .AddFluentValidation(c =>
                {
                    c.ValidatorFactoryType = typeof(HttpContextServiceProviderValidatorFactory);
                })
                .AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; });
            services.AddMediator();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHostApplicationLifetime lifetime)
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

            app.UseAuthentication();
            CORSConfiguration.UseCORS(app);

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Smart Restaurant api v1");
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);

            });
            var defaultDateCulture = "fr-FR";
            var cultureInfo = new CultureInfo(defaultDateCulture);
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ",";

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(cultureInfo),
                SupportedCultures = new List<CultureInfo> {
                    cultureInfo,
                },
                SupportedUICultures = new List<CultureInfo> {
                    cultureInfo,
                }
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });


        }

    }

}