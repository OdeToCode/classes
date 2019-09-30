using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Movies
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder()
                           .ConfigureWebHostDefaults(b =>
                           {
                               b.UseStartup<Startup>();
                           })
                           .ConfigureLogging(log =>
                           {
                               log.AddConsole();
                               log.SetMinimumLevel(LogLevel.Information);
                           })
                           .ConfigureAppConfiguration(c =>
                           {
                               c.AddJsonFile("appsetting.json", optional: true);
                               c.AddEnvironmentVariables();
                           })
                           .Build();
            host.Run();
        }
    }
}
