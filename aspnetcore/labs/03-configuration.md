# Lab 03 - A Comnfigurable Hello World

The next business requirement is to place a feiendly greeting on the home page of the CoreMovies application. Also, remove the exiting carousel. 

Here are some specific details:

- There are two possible greeting messages. One for the morning (noon, or earlier), one for the evening (after 12PM). Display the appropriate message based on the server time.

- The greeting messages must live in the configuration system (appsettings.json, environment variables, etc.)

- You should bind the two possible greetings to a single object.

- The home page should recieve the greeting configuration via dependency injection.

## Tips

- The home page of the application is `Pages\Index.cshtml`.

- The model for the home page is `Pages\Index.cshtml.cs`.

- When the configuration values are properly registered in `ConfigureServices`, you should be able to accept the configuration values in the constructor of the page model.

- You can bind to page model properties from the page.