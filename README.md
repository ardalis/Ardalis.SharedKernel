![Beakpoint Insights Logo](https://beakpointinsights.com/hubfs/Logo%20Side%20by%20Side%20742x212-1.png)

# Beakpoint Insights SharedKernel
This repository contains the SharedKernel library for Beakpoint Insights projects. The SharedKernel library contains common classes and utilities that are used across multiple projects.

## Packaging
To package a new version of this library:
- Update the version number in the `SharedKernel.csproj` file. You can do that by editing the file directly, or by clicking on the project in Visual Studio and updating the version number in the properties window.
- Build the project in Visual Studio by right-clicking on the `Beakpoint.SharedKernel `project and selecting `Pack`.

## Deploying to NuGet
To deploy a new version of this library to NuGet:
- Open a command prompt and navigate to the `bin\Release` folder of the `Beakpoint.SharedKernel` project.
- Run the following command to push the package to NuGet:
  ```
  dotnet nuget push Beakpoint.SharedKernel.<version>.nupkg --source https://api.nuget.org/v3/index.json --api-key <API_KEY> 
  ```