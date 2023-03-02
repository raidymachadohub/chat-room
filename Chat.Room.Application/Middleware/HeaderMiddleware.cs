namespace Chat.Room.Application.Middleware
{
    public class HeaderMiddleware
    {
        private readonly RequestDelegate _next;
        
        public HeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var name = "_u";
            var cookie = context.Request.Cookies[name];
            if (cookie != null)
                if (!context.Request.Headers.ContainsKey("Authorization"))
                    context.Request.Headers.Append("Authorization", "Bearer " + cookie);

            await _next.Invoke(context);
        }
    }
}