using Microsoft.EntityFrameworkCore;
using Ristorante.Application.Abstractions.Services;
using Ristorante.Application.Services;
using Ristorante.Models.Context;
using Ristorante.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MyDbContext>(conf =>
{
    conf.UseSqlServer("data source=localhost;Initial catalog=Ristorante;User Id=ristorante;Password=ristorante;TrustServerCertificate=True");
});
builder.Services.AddScoped<IUtenteService, UtenteService>();
builder.Services.AddScoped<UtenteRepository>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*app.Use(async (HttpContext context, Func<Task> next) =>
{
    //await context.Response.WriteAsync("Prova");
    await next.Invoke();
});*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();




