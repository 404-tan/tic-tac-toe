using TicTacToe.Backend.Domain;

public interface IResultadoRepository
{
    Task<bool> CreateResultadoAsync(Resultado resultado);
    Task<Resultado[]> GetLastVencedoresAsync(int count = 10);
}