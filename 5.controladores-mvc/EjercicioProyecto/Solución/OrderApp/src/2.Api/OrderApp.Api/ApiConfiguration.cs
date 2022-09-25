using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrderApp.Api.Middlewares;
using OrderApp.Services.Contracts;
using OrderApp.Services.MemoryServices;
using System.Reflection;

namespace OrderApp.Api
{
    public static class ApiConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services) 
        {
            services.AddSingleton<ICustomerService, CustomerMemoryService>()
                    .AddSingleton<IProductsService, ProductMemoryService>()
                    .AddControllers()
                    .AddApplicationPart(typeof(ApiConfiguration).GetTypeInfo().Assembly)
                    .AddControllersAsServices();
        }

        public static WebApplication UseApiConfiguration(this WebApplication app)
        {
            app.UseMiddleware<ExceptionsMiddleware>();

            return app;
        }

        public static ControllerActionEndpointConventionBuilder MapApiEndpoints(this IEndpointRouteBuilder endpoints)
        {
            return endpoints.MapControllers();
        }
    }
}
