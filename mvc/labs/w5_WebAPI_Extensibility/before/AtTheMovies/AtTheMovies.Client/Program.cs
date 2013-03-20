using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace AtTheMovies.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:26544");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync("/api/movie").Result;
            var movies = response.Content.ReadAsAsync<IEnumerable<Movie>>().Result;
            foreach(dynamic movie in movies)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }

  
}
