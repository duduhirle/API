


// Cria o construtor da aplicação
// Ler o appsetting.json
// E prepara a lista de serviços que a API vai usar.
using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// PARTE 1 - REGISTRAR OS SERVIÇOS ( o que a API VAI TE DE DISPONIVEL)
// Habilita o uso de controllers na API (as classes da pasta controllers)

builder.Services.AddControllers();
// Registra o EscolaContext ( a "ponte" com o banco) para a API

builder.Services.AddDbContext<EscolaContext>( options => 
    
        options.UseSqlServer(builder.Configuration.GetConnectionString("Escola"))
    
      // diz o que o banco é SQL Server e busca a connection string chamada "Escola"
      // dentro da secao ConnectStrings do appsettings.json

    );


// Novo: Quando alguem pedir ICursoRepository, a API entrega um CursoRepository
builder.Services.AddScoped<ICursoRepository, CursoRepository>();




// Monta a aplicacao com tudo o que foi registrado acima
// Daqui pra baixo nao da mais pra registrar servicos
var app = builder.Build();

// Parte 2 --- O Caminho de cada requisição (pipeline) =======l

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
// Se alguem acessar pelo HTTP, a API redireciona para HTTPS
app.UseHttpsRedirection();
// Verificar as permissoes de acesso. (Vamo usar para quando tivermos login)
app.UseAuthorization();
// Api/Curso - liga as rotas definidas no controllers
app.MapControllers();

app.MapGet("/api/curso", (EscolaContext db) => db.Curso.ToList());
// Liga a API e deixa ela esperando as requisições
app.Run();
