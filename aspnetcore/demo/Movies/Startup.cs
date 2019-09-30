using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Movies
{
    public class Startup 
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Configure(
            IApplicationBuilder app, 
            ILogger<Startup> logger, 
            IWebHostEnvironment environment)
        {
            if(environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            
            app.UseStatusCodePages();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(e =>
            {
                e.MapGet("/error", ctx =>
                {
                    throw new Exception("Ouch!");
                });

                e.MapGet("/speak", async ctx =>
                {
                    logger.LogInformation("I wil speak...");
                    await ctx.Response.WriteAsync(configuration["Greeting"] ?? "No message");
                });
            });

            
        }

       
    }
}
