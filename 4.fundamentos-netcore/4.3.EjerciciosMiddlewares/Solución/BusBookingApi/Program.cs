using BusBookingApi.Clientes;
using BusBookingApi.Middlewares;
using BusBookingApi.Random;
using BusBookingApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<EndpointLoggingService>();
builder.Services.AddSingleton<ISingletonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<IClientsService, ClientsService>();

var app = builder.Build();

app.UseCustomExceptionHandler();
app.UseMiddleware<EndpointLoggerMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapGet("/logscounter", (EndpointLoggingService endpointLoggingService) => endpointLoggingService.GetElements());

app.MapRandomEndpoints()
    .MapClientEndpoints();

app.Run();

