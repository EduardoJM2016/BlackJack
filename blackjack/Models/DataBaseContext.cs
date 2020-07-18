using Microsoft.EntityFrameworkCore;

namespace blackjack.Models
{
    class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Carta> Cartas { get; set; }
    }
}