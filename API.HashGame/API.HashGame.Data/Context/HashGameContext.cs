using API.HashGame.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace API.HashGame.Data.Context
{
    public class HashGameContext : DbContext
    {
        public HashGameContext(DbContextOptions<HashGameContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>().HasKey(m => m.Id);

            base.OnModelCreating(builder);
        }
    }
}