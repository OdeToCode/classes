# Working with ASP.NET Core Controllers

The new business requirements will require the following three *API* endpoints:

- Retrieve all movies
- Retrieve a single movie by ID
- Retrieve all movies whose name _starts_ with a value

You should return all data in JSON format.

## Tips

- ASPNET controllers are the best fit for building APIs.

- Place your controller class in a `Controllers` folder and derive from the base `Controller` type.

- Think about how to use routing to distinguish between a request for a movie with an ID, and a request for movies that starts with a given value. Both these operations take a single parameter. `[Route]` is the preferred routing mechanism. Note that not all parameters have to be in the path segment.

- You'll need to expand the features of IMovieData

- Think about what should happen if a request to find a movie by ID fails to find a movie. 
