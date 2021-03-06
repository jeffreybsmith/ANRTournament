﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using ANRTournament.Models;
using ANRTournament.Services;

namespace ANRTournament
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=ANRTournament;Trusted_Connection=True;";

            services.AddScoped<ICardsService, NetrunnerDBService>();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ANRTournamentContext>(options =>
                    options.UseSqlServer(connectionString));
            services.AddMvc(
                
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseDeveloperExceptionPage();
            app.UseMvc(routes =>
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Cards}"  
                )    
            );

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
