
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.Backend.Domain;

[Table("Resultados")]
public class Resultado(string vencedor, DateTime dataHora)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; }
    [Column(TypeName = "character varying(1)")]
    public string Vencedor { get; init; } = vencedor;
    [Column(TypeName = "timestamp")]
    public DateTime DataHora { get; init; } = dataHora;
}
