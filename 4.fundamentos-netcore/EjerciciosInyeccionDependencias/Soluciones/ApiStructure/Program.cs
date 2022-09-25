using ApiStructure.Models;
using ApiStructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IContactService, ContactsService>()
                .AddTransient<ITrasientRandomNumberService, RandomNumberService>()
                .AddScoped<IScopeRandomNumberService, RandomNumberService>()
                .AddSingleton<ISinglentonRandomNumberService, RandomNumberService>();

var app = builder.Build();

app.MapGet("/equals", (HttpContext http, ISinglentonRandomNumberService randomServiceSinglenton) => 
{
    var randomServiceSinglenton2 = http.RequestServices.GetService<ISinglentonRandomNumberService>()!;

    return $"Number1: {randomServiceSinglenton.GetRandomNumber()}; Number2: {randomServiceSinglenton2.GetRandomNumber()}";
});

app.MapGet("/diferents", (HttpContext http, ITrasientRandomNumberService randomServiceTrasient) =>
{
    var randomServiceTrasient2 = http.RequestServices.GetService<ITrasientRandomNumberService>()!;

    return $"Number1: {randomServiceTrasient.GetRandomNumber()}; Number2: {randomServiceTrasient2.GetRandomNumber()}";
});

app.MapGet("/scope", (HttpContext http, IScopeRandomNumberService randomServiceScope) =>
{
    var randomServiceScope2 = http.RequestServices.GetService<IScopeRandomNumberService>()!;

    return $"Number1: {randomServiceScope.GetRandomNumber()}; Number2: {randomServiceScope2.GetRandomNumber()}";
});

app.MapGet("/contacts", (IContactService contactService) => contactService.GetContacts());

app.MapGet("/contacts/{id}", (HttpContext http, int id, IContactService contactService) =>
{
    var contact = contactService.GetContact(id);
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

app.MapPut("/contacts/{id}", async (HttpContext http, int id, ContactRequest contactRequest, IContactService contactService) =>
{
    try 
    {
        contactService.UpdateContact(id, contactRequest.Name, contactRequest.TelephoneNumber);
        return;
    }
    catch (Exception ex) 
    {
        http.Response.StatusCode = 404;
    }
});

app.MapPost("/contacts", (ContactRequest contact, IContactService contactService) => 
    contactService.CreateContact(contact.Name, contact.TelephoneNumber));

app.MapDelete("/contacts/{id}", (HttpContext http, int id, IContactService contactService) =>
{
    try
    {
        contactService.DeleteContact(id);
        return;
    }
    catch (Exception ex)
    {
        http.Response.StatusCode = 404;
    }
});

app.Run();
