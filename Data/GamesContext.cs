using Microsoft.EntityFrameworkCore;

namespace HashGame.Models
{
    public class DbContextGame : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContextGame(DbContextOptions<DbContextGame> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>().HasKey(m => m.id);
            base.OnModelCreating(builder);
        }
    }
}