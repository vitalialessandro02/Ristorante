

using Ristorante.Application.Middlewares;

namespace Ristorante.Application.Extensions
{
    public static class MiddlewareExtension
    {
        public static WebApplication? AddApplicationMiddleware(this WebApplication? app)
        {
            app.UseMiddleware<MiddlewareExample>();
            return app;
        }
    }
}
