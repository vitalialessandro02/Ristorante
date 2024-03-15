using Ristorante.Web.Extensions;
using Ristorante.Application.Extensions;
using Ristorante.Application.Middlewares;
using Ristorante.Models.Extensions;


var builder = WebApplication.CreateBuilder(args);

// INIZIALIZZO I SERVIZI

builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();

//INIZIALIZZO I MIDDLEWARE

app.AddWebMiddleware()
    .AddApplicationMiddleware();

app.Run();
