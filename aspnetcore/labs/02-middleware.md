# Lab 02 - A New Project

You've been given the requirement to start a new ASP.NET Core Web Application named `CoreMovies`. You'll want to start the application using the Razor pages (not MVC) template (`dotnet new razor`).

## A New Requirement

The first feature to add to the new app is a security related feature. The business is worried about other websites embedding CoreMovies in thier own pages. They want you to take some steps to help prevent this scenario.

A [Content-Security-Policy](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy) can help your web site avoid XSS attacks and other malicious activities on the web, like click-jacking and iframe-ing.

For CoreMovies, you'll need to add a [frame-ancenstors](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Content-Security-Policy/frame-ancestors) CSP header to help keep your site out of other site's iframes.

```text
Content-Security-Policy: frame-ancestors 'none';
```

## Provide the Feature with Custom Middleware

The ultimate goal is to have add a single line of code in Startup.cs. 

```csharp
app.SetDefaultCsp();
```

The idea is that in the future, we might add additional CSP instructions. For now, you'll just need an extension method for `IApplicationBuilder` that adds new middleware to the application's pipeline.

The new middleware should write the CSP header into every response.