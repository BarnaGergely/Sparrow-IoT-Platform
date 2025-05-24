# Sparrow

`dotnet ef migrations add InitialCreate --output-dir Common/Data/Migrations`

`dotnet ef database update`

`ng generate service shared/services/sensors`

`ng generate class shared/models/measurement --type=model --skip-tests`

`ng generate component pages/home`

- ASP.NET Minimal API up to date docs with examples: https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api

- [Web app url](https://localhost:60958/)
- [IoT API Swagger](http://localhost:5141/swaggger)
- [IoT API Swagger HTTPS](https://localhost:7208/swagger/index.html)
- [Web API Swagger](http://localhost:5162/swaggger)
- [Web API Swagger HTTPS](https://localhost:7131/swagger/index.html)
- [Web API Open API](https://localhost:7131/openapi/v1.json)

# Tasks

- 18 Create very basic navigation menu
    - Devices
    - Dashboard
    - Home
- 19 Create devices page
    - List devices in a list
    - delete button
- 20 Create device info page
- 22 - Edit, create, delete device
- 23 Sensors list on device page
- 26 - Edit, create, delete sensor
- 28 - Visualize one graph on dashboard
- 29 - customize dashboard
- 31 - Create step by step setup guide
- Auth guard
- Better Auth service
- Better 
