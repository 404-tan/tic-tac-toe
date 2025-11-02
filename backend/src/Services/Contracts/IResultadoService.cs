using TicTacToe.Backend.Services.Dtos.Requests;
using TicTacToe.Backend.Services.Dtos.Responses;

namespace TicTacToe.Backend.Services.Contracts;

public interface IResultadoService
{
    Task<GravarResultadoResponse> GravarResultadoAsync(GravarResultadoRequest request);
    Task<UltimosVencedoresResponse> GetUltimosVencedoresAsync();
}