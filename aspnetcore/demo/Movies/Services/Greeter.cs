using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Services
{
    public interface IGreeter
    {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private readonly IConfiguration configuration;

        public Greeter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetGreeting()
        {
            return configuration["Greeting"] ?? "There is no greeting";
        }
    }
}
