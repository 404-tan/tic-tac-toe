namespace TicTacToe.Backend.Infra.Data;

using Microsoft.EntityFrameworkCore;
using TicTacToe.Backend.Infra.Persistence.Contexts;


public static class DataSeeder
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var db = services.GetRequiredService<TicTacToeContext>();
        db.Database.Migrate();
    }
}