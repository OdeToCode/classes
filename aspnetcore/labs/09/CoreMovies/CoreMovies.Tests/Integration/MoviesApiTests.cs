using CoreMovies.Data;
using CoreMovies.Entities;
using CoreMovies.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CoreMovies.Tests.Integration
{
    public class MoviesApiTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> factory;

        public MoviesApiTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task CanGetByName()
        {
            var client = GetClient();

            var response = await client.GetAsync("api/movies/Star");
            var content = JsonConvert.DeserializeObject<Movie[]>(await response.Content.ReadAsStringAsync());

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(3, content.Length);
        }

        HttpClient GetClient()
        {
            return factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddSingleton<IMovieData, InMemoryMovieData>(p =>
                    {
                        return new InMemoryMovieData(new List<Movie>
                        {
                            new Movie { Name = "Foo" },
                            new Movie { Name = "Star 1"},
                            new Movie { Name = "Star 2"},
                            new Movie { Name = "Star 3"},
                            new Movie { Name = "Boo" }
                        });
                    });
                });
            }).CreateClient();
        }
    }
}
