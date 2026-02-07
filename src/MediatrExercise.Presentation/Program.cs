using MediatrExercise.Application.ServiceContainer;
using MediatrExercise.Presentation.Middlewares;
using MediatrExercise.Presentation.Products.Endpoints;
using Scalar.AspNetCore;
using Serilog;
using SimpleStartup;

var builder = WebApplication.CreateBuilder(args).AddSimpleStartup() as WebApplicationBuilder;
Log.Logger = LoggerConfig.CreateLogger();
builder.Host.UseSerilog(Log.Logger);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionMiddleware>();

var app = builder.Build().UseSimpleStartup() as WebApplication;
app.UseSerilogRequestLogging();
app.MapOpenApi();
app.MapScalarApiReference();
ProductEndpoints.Map(app);
app.UseExceptionHandler();

app.Run();