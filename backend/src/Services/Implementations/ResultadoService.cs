namespace TicTacToe.Backend.Services.Implementations;

using System.Threading.Tasks;
using TicTacToe.Backend.Domain;
using TicTacToe.Backend.Services.Contracts;
using TicTacToe.Backend.Services.Dtos.Requests;
using TicTacToe.Backend.Services.Dtos.Responses;
using TicTacToe.Backend.Services.Exceptions;

public class ResultadoService : IResultadoService
{
    private readonly IResultadoRepository _resultadoRepository;
    public ResultadoService(IResultadoRepository resultadosRepository)
    {
        _resultadoRepository = resultadosRepository;
    }

    public async Task<GravarResultadoResponse> GravarResultadoAsync(GravarResultadoRequest request)
    {
        if (request.Vencedor != "X" && request.Vencedor != "O" && request.Vencedor != "E")
        {
            throw new BusinessValidationException("O campo Vencedor deve ser 'X', 'O' ou 'E' (empate).");
        }

        var resultado = new Resultado(request.Vencedor!, DateTime.UtcNow);
        var sucesso = await _resultadoRepository.CreateResultadoAsync(resultado);
        return new GravarResultadoResponse(sucesso);
    }
    public async Task<UltimosVencedoresResponse> GetUltimosVencedoresAsync()
    {
        var resultados = await _resultadoRepository.GetLastVencedoresAsync();
        var ultimosVencedoresDto = resultados
            .Select(r => new ResultadoDTO(r.Vencedor, r.DataHora))
            .ToArray();
        return new UltimosVencedoresResponse(ultimosVencedoresDto);
    }
}