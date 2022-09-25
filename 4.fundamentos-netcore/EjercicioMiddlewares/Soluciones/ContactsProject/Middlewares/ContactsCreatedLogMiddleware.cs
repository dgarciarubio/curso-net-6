using System.Net;

namespace ContactsProject.Middlewares
{
    public class ContactsCreatedLogMiddleware
    {
        private readonly RequestDelegate _next;

        public ContactsCreatedLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);

            if (context.Request.Method == HttpMethod.Post.ToString() &&
                context.Request.Path == "/contacts" &&
                context.Response.StatusCode == (int)HttpStatusCode.Created)
            {
                Console.WriteLine("Customer created!");
            }

        }
    }
}
