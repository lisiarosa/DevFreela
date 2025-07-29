using DevFreela.API.ExceptionHandler;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FreelanceTotalCostConfig>( //Aqui estou vinculando a classe(model) que eu criei
    builder.Configuration.GetSection("FreelanceTotalCostConfig") //Estou parametrizando isso para conseguir acessar aquilo que criei lá no arquivo appsetings.json
    );

builder.Services.AddSingleton<IConfigService, ConfigService>();
builder.Services.AddDbContext<DevFreelaDbContext>(o => o.UseInMemoryDatabase("DevFreelaDb")); //Adicionando o contexto do banco de dados, nesse caso estou usando um banco de dados em memória, mas poderia ser um banco de dados real como SQL Server, MySQL, etc.


builder.Services.AddExceptionHandler<ApiExceptionHandler>(); //Registrando o manipulador de exceções
builder.Services.AddProblemDetails(); // Para caso tenha falhas, adicione detalhes no erro.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build(); //Antes do Build é a parte de configurações, antes dele tem que colocar a injeção de dependências. Depois dele é a parte onde seleciona o que vai ser usado.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())


{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
