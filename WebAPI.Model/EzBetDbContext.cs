using Microsoft.EntityFrameworkCore;
using WebAPI.Model.Entities;

namespace WebAPI.Model
{
    public class EzBetDbContext : DbContext
    {
        public DbSet<Game> Game { get; set; }
        public DbSet<Bet> Bets { get; set; }

        public EzBetDbContext(DbContextOptions<EzBetDbContext> options) : base(options) { }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BetMapConfiguration());
            modelBuilder.ApplyConfiguration(new GameMapConfiguration());
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
