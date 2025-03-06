using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using NLog;
using NLog.Web;
using ReposatoryLayer.Context;
using ReposatoryLayer.Interface;
using ReposatoryLayer.Service;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Info("App is Running");

var builder = WebApplication.CreateBuilder(args);

// Set up NLog logging
builder.Logging.ClearProviders();
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllers();

// Set up database context with a connection string
var connectionString = builder.Configuration.GetConnectionString("SqlConnection");  // Make sure this key matches the key in appsettings.json
builder.Services.AddDbContext<GreetingContext>(options => options.UseSqlServer(connectionString));

// Register Business Layer and Repository
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Services.AddScoped<IGreetingRL, GreetingRL>();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Use global exception handling middleware
app.UseMiddleware<HelloGreetingApplication.Middleware.ExceptionMiddleware>();

// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();