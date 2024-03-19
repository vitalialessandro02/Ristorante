
using Microsoft.Extensions.Options;
using Ristorante.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Ristorante.Application.Middlewares
{
    public class MiddlewareExample
    {
        private RequestDelegate _next;
        public MiddlewareExample(RequestDelegate next
            )
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context
            ,IDettaglioOrdineService dettaglioOrdineService
            ,IPortataService portataService
            , IOrdineService ordineService
            , IUtenteService utenteService
            , IConfiguration configuration
            
            )
        {
            context.RequestServices.GetRequiredService<IPortataService>();
            context.RequestServices.GetRequiredService<IOrdineService>();
            context.RequestServices.GetRequiredService<IDettaglioOrdineService>();
            context.RequestServices.GetRequiredService<IUtenteService>();
            
            await _next.Invoke(context);
        }
    }
}
