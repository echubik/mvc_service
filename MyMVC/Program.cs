using MVC.Project.Infrastructure.Clients;
using MVC.Project.Infrastructure.Clients.HttpClients;
using MVC.Project.Infrastructure.Services;
using MVC.Project.Settings;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.Configure<RegistrySettings>(builder.Configuration.GetSection("RegistrySettings"));

builder.Services.AddTransient<IRegistryClient, RegistryHttpClient>();
builder.Services.AddTransient<RegistryService>();

var app = builder.Build();

app.MapControllers();

app.Run();
