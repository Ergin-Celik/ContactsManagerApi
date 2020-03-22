using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Repositories;
using Business.Interfaces;
using Business.Managers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace Service
{
    public class Startup
    {
        private static IConfiguration _baseConfig;
        private static CustomConfiguration _customConfig;


        public Startup(IConfiguration config)
        {
            _baseConfig = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureConfiguration(services);
            
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson();

            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(_customConfig.Database.ConnectionString));
            
            ConfigureSwagger(services);

            ConfigureJwtAuthentication(services);

            ConfigureManagers(services);

            ConfigureRepositories(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(_customConfig.Swagger.EndpointUrl, _customConfig.Swagger.EndpointName);
                    c.RoutePrefix = string.Empty;
                });
            }
            
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = feature.Error;

                var result = JsonConvert.SerializeObject(new { 
                    Exception = exception.GetType().Name,
                    Message = exception.Message
                });
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }));

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }

        private void ConfigureConfiguration(IServiceCollection services)
        {
            //Objet représentant la configuration de l'app.
            _customConfig = new CustomConfiguration();
            _baseConfig.Bind("Configuration", _customConfig);
            services.AddSingleton(_customConfig);
        }

        private void ConfigureManagers(IServiceCollection services)
        {
            services.AddTransient<IAddressManager, AddressManager>();
            services.AddTransient<IContactManager, ContactManager>();
            services.AddTransient<IEnterpriseManager, EnterpriseManager>();
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddTransient<IUserManager, UserManager>();
        }

        private void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IEnterpriseRepository, EnterpriseRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        private void ConfigureSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contacts Manager API", Version = "v1" });
                c.IncludeXmlComments(_customConfig.Swagger.XmlDocumentationFilePath);
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                     new OpenApiSecurityScheme
                     {
                       Reference = new OpenApiReference
                       {
                         Id = "Bearer",
                         Type = ReferenceType.SecurityScheme
                       }
                      },
                      new string[] { }
                    }
                  });
            });
        }

        private void ConfigureJwtAuthentication(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(_customConfig.JwtToken.SecretKey);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
