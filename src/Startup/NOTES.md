# Sparrow IoT Server Development Notes

## Tasks

- [ ] Fix proxy issue in Angular
	- https://learn.microsoft.com/en-us/aspnet/core/client-side/spa/intro?view=aspnetcore-9.0&preserve-view=true#developing-single-page-apps
	- proxy.conf.js
	- SpaProxy
- [ ] Refactor API Config in Program.cs

## Commands
- Create Migration: `dotnet ef migrations add MegrationName --output-dir src/Infrastructure/Common/Data/Migrations`
- Apply migration: `dotnet ef database update`
- Update Angular: `cd src/webapp.client`, `npm update --save`
	- This might break the app: `npm audit fix --force`
