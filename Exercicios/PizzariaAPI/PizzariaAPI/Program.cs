using PizzariaAPI.Contexts;
using PizzariaAPI.Interfaces;     // NOVO
using PizzariaAPI.Repositories;   // NOVO
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<PizzariaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Pizzaria")));

// NOVO: quando alguém pedir IPizzaRepository, a API entrega um PizzaRepository.
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();