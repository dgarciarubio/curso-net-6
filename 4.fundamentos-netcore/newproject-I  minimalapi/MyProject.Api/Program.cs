using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                     .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
                     .AddUserSecrets<Program>()
                     .AddEnvironmentVariables();

builder.Services.Configure<Settings>(builder.Configuration);

var app = builder.Build();

var secret = builder.Configuration["Secret"];

app.MapGet("/secret", () => secret);

app.MapGet("/secretupdate", (IOptionsSnapshot<Settings> options) => options.Value.Secret);

var students = new List<Student>();

app.MapGet("/students", () => students);

app.MapGet("/students/{id}", (HttpContext http, int id) => 
{
    var student = students.FirstOrDefault(student => student.Id == id);
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

app.MapPut("/students/{id}", (HttpContext http, int id, Student studentRequest) => 
{
    var student = students.FirstOrDefault(student => student.Id == id);
    if (student != null) 
    {
        students.Remove(student);
        students.Add(studentRequest);
        http.Response.StatusCode = 200;
    }
    else 
    {
        http.Response.StatusCode = 404;
    }
});

app.MapPost("/students", (Student student) => students.Add(student));

app.MapDelete("/students/{id}", (HttpContext http, int id) =>
{
    var student = students.FirstOrDefault(student => student.Id == id);
    if (student != null)
    {
        students.Remove(student);
    }
    else
    {
        http.Response.StatusCode = 404;
    }
});

app.Run();

public class Settings
{
    public string Secret { get; set; }
}

public class Student 
{
    public int Id { get; set; }
    public string Name { get; set; }
}
