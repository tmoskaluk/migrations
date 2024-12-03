using Cars.Api.Middleware;
using Cars.Dependency;
using Cars.Sales.Core.Infrastructure;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: false).Build();
LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));
var loggerNamespace = $"{typeof(AppLogger).Namespace}.{nameof(AppLogger)}";
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetLogger(loggerNamespace);

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseNLog();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddCarsProject(builder.Configuration);

    var app = builder.Build();
    //CarsStartup.EnsureDatabaseStructure(app.Services);

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
