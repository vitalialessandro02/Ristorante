﻿using FluentValidation;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Application.Services;


namespace Ristorante.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(
            AppDomain.CurrentDomain.GetAssemblies()
            .SingleOrDefault(assembly => assembly.GetName().Name == "Ristorante.Application")
            );
            services.AddScoped<IUtenteService, UtenteService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IOrdineService,OrdineService>();
            services.AddScoped<IPortataService, PortataService>();
            services.AddScoped<IDettaglioOrdineService, DettaglioOrdineService>();
            return services;
        }
    }
}
