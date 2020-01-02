using ezBet.WebAPI.Model.Entities;
using Microsoft.EntityFrameworkCore;


namespace ezBet.WebAPI.Model
{
    public class EzBetDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public EzBetDbContext(DbContextOptions<EzBetDbContext> options) : base(options) { }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BetMapConfiguration());
            modelBuilder.ApplyConfiguration(new GameMapConfiguration());
            modelBuilder.ApplyConfiguration(new TaskMapConfiguration());
            modelBuilder.ApplyConfiguration(new UserMapConfiguration());
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
