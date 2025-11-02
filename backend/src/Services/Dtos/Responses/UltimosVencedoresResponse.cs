namespace TicTacToe.Backend.Services.Dtos.Responses;
public record ResultadoDTO(string Vencedor, DateTime DataPartida); 
public record UltimosVencedoresResponse(ResultadoDTO[] UltimosVencedores);