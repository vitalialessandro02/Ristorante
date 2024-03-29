﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Ristorante.Models.Context;
using Ristorante.Models.Repositories;

namespace Ristorante.Models.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddModelServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("MyDbContext"));
            });

            services.AddScoped<OrdineRepository>();
            
            services.AddScoped<DettaglioOrdineRepository>();

            services.AddScoped<UtenteRepository>();

            services.AddScoped<PortataRepository>();
            
            return services;
        }
    }
}
