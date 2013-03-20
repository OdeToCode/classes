using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using AtTheMovies.Handlers;
using Newtonsoft.Json.Linq;

namespace AtTheMovies.Client
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = HttpClientFactory.Create(new ConsoleLoggingHandler());
            client.BaseAddress = new Uri("http://localhost:8080");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("/movie").Result;

            var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            foreach (dynamic movie in movies)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }

  
}
