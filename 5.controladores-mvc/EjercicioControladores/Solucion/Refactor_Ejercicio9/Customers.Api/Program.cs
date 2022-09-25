using Customers.Services.Domain;
using Customers.Services.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration)
                .AddSingleton<ICustomersService, CustomerService>()
                .AddSwaggerGen()
                .AddControllers();

var app = builder.Build();

app.UseSwagger()
   .UseSwaggerUI();

app.MapControllers();

app.Run();
