﻿
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
            , IOrdineService aziendaService
             ,IUtenteService utenteService
            , IConfiguration configuration
            
            )
        {
            
            context.RequestServices.GetRequiredService<IOrdineService>();
            context.RequestServices.GetRequiredService<IUtenteService>();
            //Implementiamo il codice effettivo del nostro middleware

            //Per andare al middleware successivo dobbiamo chiamare _next.Invoke();
            //context.Response.WriteAsync("Blocco la chiamata");
            await _next.Invoke(context);
        }
    }
}
