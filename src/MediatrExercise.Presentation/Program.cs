using MediatrExercise.Application.ServiceContainer;
using MediatrExercise.Presentation.Middlewares;
using MediatrExercise.Presentation.Products.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionMiddleware>();

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
ProductEndpoints.Map(app);
app.UseExceptionHandler();

app.Run();