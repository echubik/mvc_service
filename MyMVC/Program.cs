using MyMVC;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.Configure<AppSettings>(builder.Configuration);

var app = builder.Build();
app.MapControllers();

app.Run();
