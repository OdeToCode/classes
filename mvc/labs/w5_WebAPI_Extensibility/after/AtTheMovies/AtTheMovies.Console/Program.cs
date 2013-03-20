using System;
using System.Web.Http;
using System.Web.Http.SelfHost;
using AtTheMovies.Controllers;
using AtTheMovies.Handlers;

namespace AtTheMovies.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8080");
            config.MessageHandlers.Add(new ConsoleLoggingHandler());

            config.Routes.MapHttpRoute(
                "default", 
                "{controller}/{id}",                
                new { id = RouteParameter.Optional });

            Type type = typeof(MovieController);

            var server = new HttpSelfHostServer(config);
            server.OpenAsync();
            System.Console.WriteLine("Server started");
            System.Console.ReadLine();
        }
    }
}
