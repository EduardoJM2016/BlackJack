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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayingCard>().HasKey(o => o.Id);
        }
    }
}