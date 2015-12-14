using System.Web;
using System.Xml.Linq;
using Movies.Domain;

namespace Movies.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal sealed class Configuration : DbMigrationsConfiguration<Movies.Infrastructure.MovieData>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Movies.Infrastructure.MovieData context)
        {
            var resourceName = "Movies.App_Data.movies.xml";
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
                context.Movies.AddOrUpdate(m=>m.Title, movies);     
        }
    }
}
