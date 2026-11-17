// Site como referencia de estudo: https://quartz-sock-895.notion.site/Database-First-Scaffold-1891d6b26e178306b6480154092517de#a681d6b26e17826ca7c581a66ef6e959 // Tutorial

// Passo a Passo
1 - Criar um projeto - API Web ASP.NET CORE;

2 - Nome do Projeto API_BANCO_PRIMEIRO;

3 - .NET 10 - selecionado configurar HTTPS
    habilitar - usar controlers.;
    
4 - Deletar - WeatherForecast.cs  e                      WeatherForecastController.cs;


5 - No nome do Projeto API_BANCO_PRIMEIRO
    botão direito (Abrir no Terminal)
    
    Comandos para executar 1 por 1

    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 10.*

    dotnet add package Microsoft.EntityFrameworkCore.Design --version 10.*


    dotnet tool install --global dotnet-ef

Alterar o Database=Escola

dotnet ef dbcontext scaffold "Server=(localdb)\MSSQLLocalDB;Database=Escola;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir Contexts --context EscolaContext --no-pluralize --no-onconfiguring;


6 - Confirmar se Models e Context foram criados.


7 - Configurar o ConnectionString colar abaixo de AllowedHosts

Se necessário mudar o nome "Escola"

"AllowedHosts": "*",
"ConnectionStrings": {
  "Escola": "Server=(localdb)\\MSSQLLocalDB;Database=Escola;Trusted_Connection=True;TrustServerCertificate=True;"
}
 

8 - Configurar o Program.cs 

 - Adicionar abaixo de builder.Services.AddControllers();

  o resgistro do meu context


Se necessário trocar "Escola"

builder.Services.AddDbContext<EscolaContext>(options =>

        options.UseSqlServer( builder.Configuration.GetConnectionString("Escola"))

    //Diz o que o banco é SQL SERVER e busca a connection string chamada "Escola".
    //dentro da secao ConnectionStrings do appsettings.json

   );
  
  
9 - Se quiser testar rapidamente, antes de app.run()
adicionar no caso do banco escola a busca por curso.


app.MapGet("/api/cursos", (EscolaContext db) => db.Curso.ToList());


