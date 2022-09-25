using MyProject.Api.Middlewares;
using MyProject.Api.Services;

namespace MyProject.Api.Extensions
{
    public static class ProgramExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services) 
        {
            return services.AddSingleton<IStudentService, StudentsService>()
                           .AddSingleton<ITimeServiceSingleton, TimeService>()
                           .AddScoped<ITimeServiceScoped, TimeService>()
                           .AddTransient<ITimeServiceTrasient, TimeService>()
                           .AddScoped<IFormatLanguage, FormatLanguage>();
        }
    }
}
