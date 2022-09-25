using ContactsProject.Middlewares;
using ContactsProject.Models;
using ContactsProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IContactLogService, ContactLogService>();

var app = builder.Build();

var contacts = new List<Contact>();

app.MapGet("/contacts", () => contacts);

app.MapGet("/contacts/{contactId}", (HttpContext http, int contactId) =>
{
    var contact = contacts.FirstOrDefault(student => student.Id == contactId);
    if (contact != null)
    {
        return contact;
    }
    else
    {
        http.Response.StatusCode = 404;
        return null;
    }
});

app.MapPut("/contacts/{id}", (HttpContext http, int id, ContactRequest contactRequest) =>
{
    var contact = contacts.FirstOrDefault(contact => contact.Id == id);
    if (contact != null)
    {
        contact.Name = contactRequest.Name;
        contact.TelephoneNumber = contactRequest.TelephoneNumber;
        return;
    }
    else
    {
        http.Response.StatusCode = 404;
    }
});

app.MapPost("/contacts", (ContactRequest contact) =>
{
    contacts.Add(new Contact
    {
        Id = contacts.Count > 0 ? contacts.Max(contact => contact.Id) : 1,
        Name = contact.Name,
        TelephoneNumber = contact.TelephoneNumber
    });
    return;
});

app.MapDelete("/contacts/{id}", (HttpContext http, int id) =>
{
    var student = contacts.FirstOrDefault(student => student.Id == id);
    if (student != null)
    {
        contacts.Remove(student);
    }
    else
    {
        http.Response.StatusCode = 404;
    }
});

app.MapGet("/contacts/log/{id}", (int id, IContactLogService logCustomerService) =>
{
    return logCustomerService.GetContactAccessLog(id);
});

app.UseMiddleware<ContactsLogMiddleware>()
   .UseMiddleware<ContactsCreatedLogMiddleware>();

app.Run();
