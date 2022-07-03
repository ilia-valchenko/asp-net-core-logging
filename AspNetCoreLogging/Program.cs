using AspNetCoreLogging.Middlewares;
using AspNetCoreLogging.Services;
using NLog;
using NLog.Web;

// When creating a NLog Logger-object then one must provide a logger-name like NLog.LogManager.GetLogger("blah blah").
// The logger-name can also be extracted from class-context by using NLog.LogManager.GetCurrentClassLogger()
// where logger-name becomes "NameSpace.ClassName".
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
