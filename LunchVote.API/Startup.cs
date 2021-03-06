﻿using AutoMapper;
using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using LunchVote.LIB.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace LunchVote.API
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
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();
            services.AddHostedService<ElectionService>();

            // register the DbContext on the container, getting the connection string from
            // appSettings (note: use this during development; in a production environment,
            // it's better to store the connection string in an environment variable)
            var connectionString = Configuration["connectionStrings:staging"];
            services.AddDbContext<LunchVoteContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IVoteRepository, VoteRepository>();
            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddScoped<IVoteService, VoteService>();
            services.AddScoped<IProfessionalService, ProfessionalService>();
            services.AddScoped<IRestaurantService, RestaurantService>();

            // Add Database Initializer
            services.AddTransient<IDBInitializer, DBInitializer>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "LunchVoteAPI",
                    Description = "DBServer 'Vote for Lunch Application', using ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact
                    {
                        Name = "Paulo Rosa",
                        Email = "pdouglasrs@gmail.com",
                        Url = "https://www.linkedin.com/in/paulo-douglas-191a2a24/"
                    },
                    License = new License
                    {
                        Name = "MIT",
                        Url = "https://opensource.org/licenses/MIT"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, LunchVoteContext context, IDBInitializer dbInitializer)
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

            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(Program).Assembly.GetName().Name));

            context.Database.EnsureCreated();
            dbInitializer.Initialize();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LunchVote API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(
                options => options.WithOrigins("https://localhost:44313", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseMvc();
        }
    }
}
