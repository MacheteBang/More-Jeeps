using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add logging
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

builder.Host.UseSerilog(logger);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSingleton<ISightingService, SightingService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
