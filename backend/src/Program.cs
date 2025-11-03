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
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") 
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});
builder.Services.AddDbContext<TicTacToeContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors("CorsPolicy");
    using var scope = app.Services.CreateScope();
    await DataSeeder.SeedAsync(scope.ServiceProvider);
}

app.UseHttpsRedirection();

app.MapGet("/api/resultados/ultimos", async (IResultadoService resultadoService) =>
{
    try
    {
        var response = await resultadoService.GetUltimosVencedoresAsync();
        return Results.Ok(response);
    }
    catch (Exception)
    {
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
