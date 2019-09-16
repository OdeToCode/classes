using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Simple
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRazorPages();
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseRouting();

            app.UseEndpoints(e =>
            {
                e.MapRazorPages(); 
                e.MapControllers();
                e.MapGet("/hi", async ctx =>
                {
                    await ctx.Response.WriteAsync("Hello there!");
                });
            });
        }

    }
}