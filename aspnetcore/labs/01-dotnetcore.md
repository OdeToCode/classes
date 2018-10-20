# Lab 01 - .NET Core and .NET Standard

In this lab, we want to:

    - See how to work with class libraries and the .NET Standard
    - Reference a class library from a .NET Core application
    - Publish a self-contained console application

In the first section, we'll create a console application that calls into a class library.

## Setting up the Projects

All of the following steps you can achieve using the dotnet CLI.

1. Create a directory to work in, with sub-folders named `lab01` and `lib01`.

2. In `lab01`, create a new console application with the `dotnet new` command.

3. In `lib01`, create a new class library with the `dotnet new` command.

4. Using the `dotnet add` command, add a project reference *to* `lib01` *from* `lab01`.

## Setting up a Solution (Optional - for VS Users)

1. Create a .sln file in your root working directory with `dotnet new`

2. Using `dotnet sln`, add the two projects you've created to the solution file. 

3. Open your .sln file with Visual Studio to start working with the code.

## Adding Features

1. Add a public method to `Class1` in the library to return the current AppDomain's base directory. 

```csharp
public class Class1
{
    public string GetBaseDirectory()
    {
        return AppDomain.CurrentDomain.BaseDirectory;
    }
}
```

2. Add the code needed for `lab01` to retrieve and display the base directory.

```csharp
static void Main(string[] args)
{
    var directory = new Class1().GetBaseDirectory();
    Console.WriteLine(directory);
}
```

3. Build the `lab01` project using `dotnet build`.

4. Notice the file extension for the build artifact of the console application. What is the signifigance?

5. Run the application using `dotnet run` on the project and make sure you see the expected output.

## Experimenting with .NET Standard

1. Change `lib01` to target .NET standard 1.0. You can do this by editing lib01.csproj directly, or in the project properties when using Visual Studio.

### NOTE
You may see errors about assets files or projec.asstes.json files. Ignore these errors. Some tools are finicky when you change the TargetFramework up until you `dotnet restore`. 

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard1.0</TargetFramework>
  </PropertyGroup>

</Project>
```

2. Try `dotnet build`. You should recieve an error that `AppDomain` does not exist. *Why does this error happen?*

3. Change the target framework for the class library back to netstandard2.0, then use `dotnet build` to make sure you are back to a successful compile.

4. Change the target framework for the console application to `net45`. Again, ignore tooling errors.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <ItemGroup>
    <ProjectReference Include="..\lib01\lib01.csproj" />
  </ItemGroup>

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net45</TargetFramework>
  </PropertyGroup>

</Project>
```

5. Run `dotnet build` again. *What is the real reason for this build to fail?*

6. Change the app target back to `netcoreapp2.1`

## Extra Credit - The Self Contained Deployment

1. Create an `output` directory on your file system. 

2. Use `dotnet publish` to place just the files needed to run the application in the output directory. 

3. Use `dotnet` to run the application from the output directory. Note: don't use `dotnet run`, just `dotnet`.

4. Observe the files in the output directory to compare later. 

5. Use `dotnet publish` with the `--self-contained` flag to publish *everything* needed to run the app. You'll need to figure out the [RID](https://docs.microsoft.com/en-us/dotnet/core/rid-catalog). 

6. Compare the output directory to what you saw in step 4!