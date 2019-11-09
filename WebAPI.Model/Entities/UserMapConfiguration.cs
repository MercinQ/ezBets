using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAPI.Model.Entities
{
    public class UserMapConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Username).HasMaxLength(255);
            builder.Property(c => c.Password);
            builder.Property(c => c.Salt);
        }
    }
}
