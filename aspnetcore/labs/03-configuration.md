# Lab 03 - A Configurable Hello World

The next business requirement is to place a friendly greeting on the home page of the CoreMovies application. 

Here are some specific details:

- There are two possible greeting messages. One for the morning (noon, or earlier), one for the evening (after 12PM). Display the appropriate message based on the local server time.

- The greeting messages must live in the configuration system (appsettings.json, environment variables, etc.)

- You should bind the two possible greetings to a single object.

- The home page should receive the greeting configuration via IOptions and dependency injection.

## Tips

- The home page of the application is `Pages\Index.cshtml`.

- The model for the home page is `Pages\Index.cshtml.cs`.

- When the configuration values are properly registered in `ConfigureServices`, you should be able to accept the configuration values in the constructor of the page model.