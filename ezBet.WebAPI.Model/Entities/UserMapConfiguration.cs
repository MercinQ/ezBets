using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ezBet.WebAPI.Model.Entities
{
    public class UserMapConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Login);
            builder.Property(c => c.Email);
            builder.Property(c => c.Password);
            builder.Property(c => c.ResetPasswordToken);
            builder.Property(c => c.Salt);
        }
    }
}
