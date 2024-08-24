using Server.DeviceRestApi;
using Server.Application;
using Server.Infrastructure;
using Server.BlazorWebApp;

// only for Blazor test
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server.BlazorWebApp.Client.Pages;
using Server.BlazorWebApp.Components;
using Server.BlazorWebApp.Components.Account;
using Server.BlazorWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// TODO: change somehow the root location, to move the static files and the configs to BlazorWebApp project and REST APi project
// Failed attempts:
//builder.Environment.WebRootPath = "wwwRoot:; // docs: https://github.com/dotnet/aspnetcore/issues/25590
//builder.Environment.ContentRootPath = "..//Server.BlazorWebApp";

// Module service registration
builder.Services
    .AddDeviceRestApiServices()
    .AddBlazorWebAppServices();

// Dependency injection
builder.Services
    .AddDeviceRestApiDependencies()
    .AddApplicationDependencies()
    .AddInfrastructureDependencies()
    .AddBlazorWebAppDependencies();


// Test Blazor example
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

//app.UseDeveloperExceptionPage(); // Blazor exception handler TODO: integrate it, find how to use it

app.ConfigureDeviceRestApi();
app.ConfigureBlazorWebApp();

app.Run(); // TODO: Read port from configuration: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
           // TODO: HTTPS: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0#read-the-port-from-environment
