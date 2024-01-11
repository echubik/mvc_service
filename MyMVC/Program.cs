using MVC.Project;
using MVC.Project.Infrastructure.Clients;
using MVC.Project.Infrastructure.Clients.HttpClients;
using MVC.Project.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.Configure<AppSettings>(builder.Configuration);

builder.Services.AddTransient<IRegistryClient, RegistryHttpClient>();
builder.Services.AddTransient<RegistryService>();

var app = builder.Build();

app.MapControllers();

app.Run();
