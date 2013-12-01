namespace AtTheMovies.Migrations
{
    using AtTheMovies.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MovieDb context)
        {
            context.Movies.AddOrUpdate(m => m.Title,
                    new Movie { Title="Star Wars", ReleaseYear=1977, Runtime=121 },
                    new Movie { Title="E.T.", ReleaseYear=1981, Runtime=130},
                    new Movie { Title="Toy Story", ReleaseYear=1994, Runtime=90 }
                );
        }        
    }
}
