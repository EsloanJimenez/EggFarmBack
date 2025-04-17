using GranjaDeHuevo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.RoleId);

            builder.Property(r => r.RoleId).ValueGeneratedOnAdd();

            builder.Property(r => r.RoleName)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(r => r.Description)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.HasOne(p => p.UserCreationNav)
                .WithMany()
                .HasForeignKey(r => r.UserCreation)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.UserModifyNav)
                .WithMany()
                .HasForeignKey(r => r.UserModify)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(p => p.UserDeleteNav)
                .WithMany()
                .HasForeignKey(r => r.UserDelete)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
