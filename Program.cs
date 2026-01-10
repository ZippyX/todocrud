using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Text.Unicode;
using Doist.Models;
using System.Text.Encodings.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddDbContext<ProblemContext>(option => option.UseInMemoryDatabase("Doist")); // регистрация контекста бд для DI
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });

}
app.UseHttpsRedirection();
app.MapControllers();
app.MapFallbackToFile("index.html");
app.UseAuthorization();
app.UseStaticFiles(); // для обслуживания всех статических файлов
app.UseDefaultFiles(); // позволяет обслуживать index.html по умолчанию 
app.Run();

