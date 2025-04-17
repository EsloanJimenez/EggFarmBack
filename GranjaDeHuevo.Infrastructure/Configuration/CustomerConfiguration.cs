using GranjaDeHuevo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.HasKey(c => c.CustomerId);

            builder.Property(c => c.CustomerId).ValueGeneratedOnAdd();

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Phone)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(c => c.Address)
                .HasMaxLength(100);

            builder.HasOne(c => c.UserCreationNav)
                .WithMany()
                .HasForeignKey(c => c.UserCreation)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(c => c.UserModifyNav)
                .WithMany()
                .HasForeignKey(c => c.UserModify)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(c => c.UserDeleteNav)
                .WithMany()
                .HasForeignKey(c => c.UserDelete)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
