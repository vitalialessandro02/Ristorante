using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Ristorante.Application.Factories;

namespace Ristorante.Web.Extensions
{
    public static class MiddlewareExtensions
    {
        public static WebApplication? AddWebMiddleware(this WebApplication? app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.Use(async (HttpContext context, Func<Task> next) =>
            {
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        var res = ResponseFactory
                            .WithError(contextFeature.Error);
                        await context.Response.WriteAsJsonAsync(
                            res
                            ) ;
                    }
                });
            });

            app.MapControllers();
            return app;
        }
    }
}
