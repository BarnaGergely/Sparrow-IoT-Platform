# Sparrow IoT Server Development Notes

## Commands
- Create Migration: `dotnet ef migrations add MegrationName --output-dir src/Infrastructure/Common/Data/Migrations`
- Apply migration: `dotnet ef database update`
- Update Angular: `cd src/webapp.client`, `npm update --save`
	- This might break the app: `npm audit fix --force`
