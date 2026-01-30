using MediatrExercise.Application.ServiceContainer;
using MediatrExercise.Presentation.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddOpenApi();
builder.Services.AddApplicationServices();

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
ProductEndpoints.Map(app);

app.Run();