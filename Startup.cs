﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DruidsHikeStore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StoreDB;

namespace DruidsHikeStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            var configBuilder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true);
            var config = configBuilder.Build();


            Configuration = config;
           
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<StoreDB.DB.StoreDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
              b => b.MigrationsAssembly("DruidsHikeStore")


            ));
            services.AddIdentity<StoreUser, IdentityRole>(options => {
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.SignIn.RequireConfirmedEmail = true;
                }
                                )
                .AddEntityFrameworkStores<StoreDB.DB.StoreDBContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);


            services.AddScoped<StoreDB.IStoreManager, StoreDB.StoreManager>();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder
                    .AllowAnyOrigin()                    
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddAuthentication().AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = Configuration["TwitterConfig:API_KEY"];
                twitterOptions.ConsumerSecret = Configuration["TwitterConfig:API_SECRET"];
            }
            

                );

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           

            app.UseHttpsRedirection();
            app.UseCors(MyAllowSpecificOrigins);            
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<StoreDB.DB.StoreDBContext>();
                
                context.Database.EnsureCreated();
               
            }
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
