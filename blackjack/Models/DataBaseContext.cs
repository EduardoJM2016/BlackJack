using Microsoft.EntityFrameworkCore;

namespace blackjack.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<PlayingCard> PlayingCards { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}