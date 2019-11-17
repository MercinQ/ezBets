using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ezBet.WebAPI.Model.Entities
{
    public class BetMapConfiguration : IEntityTypeConfiguration<Bet>
    {
        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.ToTable("bet");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Name).HasMaxLength(255);
            builder.Property(c => c.Type);
            builder.Property(c => c.Score);
            builder.Property(c => c.Name);
            builder.Property(c => c.GameId).HasColumnName("GameId");
        }
    }
}
