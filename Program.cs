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
builder.Services.AddCors(options =>
{
    
    options.AddPolicy("AllowAll",policy =>
    {policy
       .AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader(); 
    });
});
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

app.UseDefaultFiles();
app.UseStaticFiles();

// **Важно:** UseRouting до CORS и Authorization
app.UseRouting();

app.UseCors("AllowAll");
app.UseAuthorization();

// Контроллеры и fallback
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();