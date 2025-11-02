using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Backend.Services.Dtos.Requests;
public record GravarResultadoRequest(
    [StringLength(1,ErrorMessage = "O campo Vencedor deve conter apenas um caractere.")]
    [Required(ErrorMessage = "O campo Vencedor é obrigatório.")]
    string? Vencedor);