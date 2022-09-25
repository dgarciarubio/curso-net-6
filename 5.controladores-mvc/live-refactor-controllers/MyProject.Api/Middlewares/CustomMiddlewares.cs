namespace MyProject.Api.Middlewares
{
    public class CustomMiddlewares
    {
        private readonly RequestDelegate _next;

        public CustomMiddlewares(RequestDelegate next) 
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IFormatLanguage formatLanguage) 
        {
            if (context.Request.Headers.ContainsKey("x-format")) 
            {
                var headerValue = context.Request.Headers["x-format"];
                formatLanguage.SetLanguage(headerValue);
            }

            await _next.Invoke(context);
            

            // skskjsk
            var a = "";
        }
    }
}
