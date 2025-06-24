using DevFreela.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<FreelanceTotalCostConfig>( //Aqui estou vinculando a classe(model) que eu criei
    builder.Configuration.GetSection("FreelanceTotalCostConfig") //Estou parametrizando isso para conseguir acessar aquilo que criei lá no arquivo appsetings.json
    );
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
