using Microsoft.EntityFrameworkCore;

namespace blackjack.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Carta> Cartas { get; set; }
        public DbSet<Partida> Partidas { get; set; }
    }
}