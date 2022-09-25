using Microsoft.Extensions.Options;
using MyProject.Api.Middlewares;
using MyProject.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Settings>(builder.Configuration)
                .AddSingleton<IStudentService, StudentsService>()
                .AddSingleton<ITimeServiceSingleton, TimeService>()
                .AddScoped<ITimeServiceScoped, TimeService>()
                .AddTransient<ITimeServiceTrasient, TimeService>()
                .AddScoped<IFormatLanguage, FormatLanguage>();

var app = builder.Build();

var secret = builder.Configuration["Secret"];

app.MapGet("/secret", () => secret);

app.MapGet("/secretupdate", (IOptionsSnapshot<Settings> options) => options.Value.Secret);

app.MapGet("/getdate", async (ITimeServiceSingleton singleton, ITimeServiceScoped scoped, ITimeServiceTrasient trasient, HttpContext http) => 
{
    await Task.Delay(2000);

    var singletonRequest = http.RequestServices.GetRequiredService<ITimeServiceSingleton>();
    var scopedRequest = http.RequestServices.GetRequiredService<ITimeServiceScoped>();
    var trasientRequest = http.RequestServices.GetRequiredService<ITimeServiceTrasient>();

    return $"Llamada1:               singlenton: {singleton.GetTime()}; scoped: {scoped.GetTime()}; trasient: {trasient.GetTime()}\n" +
           $"Llamada 2 seg latencia: singlenton: {singletonRequest.GetTime()}; scoped: {scopedRequest.GetTime()}; trasient: {trasientRequest.GetTime()}";
});


app.MapGet("/students", (IStudentService studentService) => studentService.GetStudents());

app.MapGet("/students/{id}", (HttpContext http, int id, IStudentService studentService) => 
{
    var student = studentService.GetStudent(id);
    if (student != null) 
    {
        return student;
    }
    else 
    {
        http.Response.StatusCode = 404;
        return null;
    }
});

app.MapPut("/students/{id}", (HttpContext http, int id, Student studentRequest, IStudentService studentService) => 
{
    try 
    {
        studentService.UpdateStudent(studentRequest.Id, studentRequest.Name);
    }
    catch (Exception ex) 
    {
        http.Response.StatusCode = 404;
    }
});

app.MapPost("/students", (Student student, IStudentService studentService) => studentService.CreateStudent(student.Id, student.Name));

app.MapDelete("/students/{id}", (HttpContext http, int id, IStudentService studentService) =>
{
    try
    {
        studentService.DeleteStudent(id);
    }
    catch (Exception ex)
    {
        http.Response.StatusCode = 404;
    }
});

app.Use(async (context, next) => {
        Console.WriteLine("Before Middleware");
        // Before the call
        await next();
        // After the call

        Console.WriteLine("After Middleware");
    })
    .UseMiddleware<CustomMiddlewares>();

app.Run();

public class Settings
{
    public string Secret { get; set; }
}
