using BusinessLayer.Interface;
using BusinessLayer.Service;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
try
{
    logger.Info("App is Running");

    var builder = WebApplication.CreateBuilder(args);

    // Ensure NLog is used as the logging provider
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add services to the container.
    builder.Services.AddControllers();
    builder.Services.AddScoped<IGreetingBL, GreetingBL>();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure Swagger
    app.UseSwagger();
    app.UseSwaggerUI();

    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "An error occurred while starting the application");
}
finally
{
    // Ensure NLog shuts down cleanly
    LogManager.Shutdown();
}
