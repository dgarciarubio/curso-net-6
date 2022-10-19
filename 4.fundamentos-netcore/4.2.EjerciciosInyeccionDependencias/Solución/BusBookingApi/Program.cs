using BusBookingApi.Clientes;
using BusBookingApi.Random;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ISingletonRandomService, RandomService>();
builder.Services.AddScoped<IScopedRandomService, RandomService>();
builder.Services.AddTransient<ITransientRandomService, RandomService>();
builder.Services.AddSingleton<IClientsService, ClientsService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapRandomEndpoints()
    .MapClientEndpoints();

app.Run();
