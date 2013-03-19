using System.Reflection;
using System.Xml.Linq;
using AtTheMovies.Domain;

namespace AtTheMovies.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AtTheMovies.Infrastructure.MovieData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AtTheMovies.Infrastructure.MovieData context)
        {
            var resourceName = "AtTheMovies.App_Data.movies.xml";
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(resourceName);
            var xml = XDocument.Load(stream);
            var movies = xml.Element("Movies")
                            .Elements("Movie")
                            .Select(x => new Movie
                            {
                                Title = (string)x.Element("Title"),
                                Director = (string)x.Element("Director"),
                                Year = (int)x.Element("Year"),
                                Length = (int)x.Element("Length")
                            }).ToArray();
            context.Movies.AddOrUpdate(m => m.Title, movies);     
        }
    }
}
