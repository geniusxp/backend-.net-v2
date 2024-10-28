using geniusxp_backend_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(
    c =>
    {
        c.EnableAnnotations();
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Back-end do GeniusXP desenvolvido em ASP.NET",
            Description = "API em C# para gerenciar ingressos, usu�rios e eventos. O GeniusXP � uma plataforma centralizada para gest�o de eventos que simplifica opera��es como inscri��es, pagamentos e check-in, enquanto aumenta o engajamento com enquetes e networking. A intelig�ncia artificial da GeniusXP utiliza as prefer�ncias dos usu�rios para oferecer uma experi�ncia altamente personalizada e otimizar o planejamento. Com an�lise de sentimento e assist�ncia virtual, a plataforma proporciona intera��es mais significativas, elevando a efici�ncia da gest�o e tornando os eventos mais impactantes para cada participante.",
            License = new OpenApiLicense() { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT") }
        });
    }
);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
