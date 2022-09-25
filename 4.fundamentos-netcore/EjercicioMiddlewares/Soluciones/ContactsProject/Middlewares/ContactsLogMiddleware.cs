using System.Net;
using ContactsProject.Services;

namespace ContactsProject.Middlewares
{
    public class ContactsLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ContactsLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IContactLogService logCustomerService)
        {
            if (context.Request.Method == HttpMethod.Get.ToString() &&
                context.Request.Path.HasValue &&
                context.Request.Path.Value.StartsWith("/contacts") &&
                context.Request.Path.Value.Split('/').Count() == 3)
            {
                var contactIdParam = context.Request.RouteValues.FirstOrDefault(r => r.Key == "contactId");
                if (contactIdParam.Value != null)
                {
                    logCustomerService.AddContactLog(int.Parse(contactIdParam.Value.ToString()!));
                }
            }

            await _next.Invoke(context);
        }
    }
}
