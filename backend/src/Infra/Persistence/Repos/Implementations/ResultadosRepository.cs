
namespace TicTacToe.Backend.Infra.Persistence.Repos.Implementations;
using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Domain;
using TicTacToe.Backend.Infra.Persistence.Contexts;

public class ResultadoRepository : IResultadoRepository
{
    private readonly TicTacToeContext _context;

    public ResultadoRepository(TicTacToeContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateResultadoAsync(Resultado resultado)
    {
        _context.Resultados.Add(resultado);
        var resultadoCriado = await _context.SaveChangesAsync();
        return resultadoCriado > 0;
    }

    public async Task<Resultado[]> GetLastVencedoresAsync(int count = 10)
    {
        var resultados = await _context.Resultados
            .Where(r => r.Vencedor == "X" || r.Vencedor == "O")
            .OrderByDescending(r => r.Id)
            .Take(count)
            .ToArrayAsync();
        return resultados;
    }
}
