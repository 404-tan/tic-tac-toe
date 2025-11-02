namespace TicTacToe.Backend.Infra.Persistence.Contexts;

using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Domain;

public class TicTacToeContext(DbContextOptions<TicTacToeContext> options) : DbContext(options)
{
    public DbSet<Resultado> Resultados { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.ToTable("Resultados");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Vencedor).IsRequired();
            entity.Property(e => e.DataHora).IsRequired();
        });
    }
}