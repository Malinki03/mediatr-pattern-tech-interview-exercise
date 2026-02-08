using MediatrExercise.Application.ServiceContainer;
using MediatrExercise.Presentation.Config;
using MediatrExercise.Presentation.Middlewares;
using MediatrExercise.Presentation.Products.Endpoints;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = LoggerConfig.CreateLogger();
builder.Host.UseSerilog(Log.Logger);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionMiddleware>();

var app = builder.Build() as WebApplication;
app.UseSerilogRequestLogging();
app.MapOpenApi();
app.MapScalarApiReference();
ProductEndpoints.Map(app);
app.UseExceptionHandler();

app.Run();