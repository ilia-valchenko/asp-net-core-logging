using AspNetCoreLogging.Middlewares;
using AspNetCoreLogging.Services;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();
//builder.Logging.AddConsole();

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();

var app = builder.Build();

// The default logging
//using var loggerFactory = LoggerFactory.Create(loggingBuilder => loggingBuilder
//    .SetMinimumLevel(LogLevel.Trace)
//    .AddConsole());

using var loggerFactory = LoggerFactory.Create(loggingBuilder => { });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// IMPORTANT! The order is important! It won't work if you will put it after UseEndpoints.
app.ConfigureGlobalExceptionLogging(loggerFactory.CreateLogger<Program>());

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
