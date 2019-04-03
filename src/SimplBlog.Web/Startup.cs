﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using SimplBlog.Web.Services;
using SimplBlog.Web.Services.Interfaces;
using SimplBlog.Core;
using SimplBlog.Data;
using Microsoft.EntityFrameworkCore;
using SimplBlog.Data.Domain;
using Microsoft.AspNetCore.Identity;

namespace SimplBlog.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var section = Configuration.GetSection("SimplBlog");

            var databaseProvider = section.GetValue<string>("DbProvider");
            var connString = section.GetValue<string>("ConnString");

            if (databaseProvider == "SqlServer")
            {
                SimplBlogSettings.DbOptions = options => options.UseSqlServer(connString);
            }

            services.AddDbContext<SimplBlogDbContext>(SimplBlogSettings.DbOptions, ServiceLifetime.Transient);
            services.AddIdentity<AppUser, IdentityRole>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.User.AllowedUserNameCharacters = null;
            })
            .AddEntityFrameworkStores<SimplBlogDbContext>()
            .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IMessageService, ConfigurationMessageService>();
        }

        // This method gets called by the runtime. 
        // Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IMessageService msg)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvcWithDefaultRoute();

            app.Run(async (context) =>
            {
                // -- Get message from configuration file. -- //
                //var message = Configuration["Message"];
                //await context.Response.WriteAsync(message);

                // -- Get message from service. -- //
                await context.Response.WriteAsync(msg.GetMessage());
            });
        }
    }
}
