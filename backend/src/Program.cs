using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Infra.Data;
using TicTacToe.Backend.Infra.Persistence.Contexts;
using TicTacToe.Backend.Services.Contracts;
using TicTacToe.Backend.Services.Dtos.Requests;
using TicTacToe.Backend.Services.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IResultadoService, TicTacToe.Backend.Services.Implementations.ResultadoService>();
builder.Services.AddScoped<IResultadoRepository, TicTacToe.Backend.Infra.Persistence.Repos.Implementations.ResultadoRepository>();
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<TicTacToeContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    using var scope = app.Services.CreateScope();
    await DataSeeder.SeedAsync(scope.ServiceProvider);
}

app.UseHttpsRedirection();


app.MapGet("/api/resultados/ultimos", async (IResultadoService resultadoService) =>
{
    try
    {
        // O resultadoService agora é injetado pelo runtime, que garante o escopo correto.
        var response = await resultadoService.GetUltimosVencedoresAsync();
        return Results.Ok(response);
    }
    catch (Exception)
    {
        // Em um cenário real, você deve logar o erro aqui.
        return Results.StatusCode(500);
    }
})
.WithName("GetUltimosVencedores");


app.MapPost("/api/resultados", async (IResultadoService resultadoService,GravarResultadoRequest request) =>
{
    try
    {
        var response = await resultadoService.GravarResultadoAsync(request);
        
        return response.Sucesso
            ? Results.Created()
            : Results.StatusCode(500);
    }
    catch (BusinessValidationException ex)
    {
        return Results.BadRequest(new { Message = ex.Message });
    } catch (Exception)
    {
        return Results.StatusCode(500);
    }
})
.WithName("CreateResultado");


app.Run();
