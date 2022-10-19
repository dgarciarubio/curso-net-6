using BusBookingApi.Middlewares;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BusBookingApi.Infrastructure.BusBookingApiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IDbConnection>(services =>
{
    return new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(BusBookingApi.Clientes.Commands.CreateCliente).Assembly);
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
builder.Services.AddApiVersioning();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BusBookingApi.Infrastructure.BusBookingApiDbContext>();
    await dbContext.Database.MigrateAsync();
}

app.UseCustomExceptionHandler();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    foreach (var version in apiVersionDescriptionProvider.ApiVersionDescriptions.Select(v => v.GroupName))
    {
        options.SwaggerEndpoint($"/swagger/{version}/swagger.json", version);
    }
});

app.MapGet("/", () => "Hello World!");
app.MapControllers();

app.Run();

public sealed class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        foreach (var version in _apiVersionDescriptionProvider.ApiVersionDescriptions.Select(v => v.GroupName))
        {
            options.SwaggerDoc(version, new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Bus Booking Api",
                Version = version
            });
        }
    }
}