# Making Movies

The goal is to start adding movies to our CoreMovies application. In the UI, we want to start by only showing the number of movies we know about, but there will be some work we need to complete before we can display this number. 

## Movie Entity

We want the models for our domain separate from the Web project, so add a class library project to the solution: `CoreMovies.Entities`. Inside, define a class to hold movie information. You'll need the following properties:

| Name | Type
--- | ---
ID | `int`
Name | `string`
Year | `int`

## Data Access

Add another class library named `CoreMovies.Data`. This is where we will keep our data access classes. Eventually we'll be using EF and SQL Server, but we're going to start with an in-memory mock database.

Start with an interface that describes the queries we need against the database.

```csharp
public interface IMovieData
{
    int Count();
    IEnumerable<Movie> GetAll();
}
```

Build an implementation of the `IMovieData` interface that works against a `List<Movie>` internally. Include some sample movies. Perhaps the class looks like:

```csharp
public class InMemoryMovieData : IMovieData
    {
        List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Name = "Star Wars", Year = 1979 },
            new Movie { Id = 2, Name = "Inception", Year = 2010 },
            new Movie { Id = 3, Name = "Cleopatra", Year = 1963 }
        };

        public int Count()
        {
            return movies.Count();
        }

        public IEnumerable<Movie> GetAll()
        {
            return from m in movies
                   orderby m.Year
                   select m;
        }
    }
```

## Web

Now, you'll need to register `InMemoryMovieData` as the service implementing `IMovieData` for the `CoreMovies.Web` app. Register the service as a **Singleton**. You'd **never** want to do this outside of test or development, obviosuly, but later we'll seemlessly switch to using SQL Server. 

Finally, inject the service into the Index page, an display the number of movies on the home page.
