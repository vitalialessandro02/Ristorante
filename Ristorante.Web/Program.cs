using Ristorante.Web.Extensions;
using Ristorante.Application.Extensions;
using Ristorante.Application.Middlewares;
using Ristorante.Models.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddWebServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration)
    .AddModelServices(builder.Configuration);

var app = builder.Build();


app.AddWebMiddleware()
    .AddApplicationMiddleware();

app.Run();
