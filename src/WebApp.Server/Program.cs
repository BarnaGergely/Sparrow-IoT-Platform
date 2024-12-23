using WebApp.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebAppServerServices();
builder.Services.AddWebAppServerDependencies();

var app = builder.Build();

app.ConfigureWebAppServer();

app.Run();