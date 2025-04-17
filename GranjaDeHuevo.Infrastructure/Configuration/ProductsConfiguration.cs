using GranjaDeHuevo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class ProductsConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder.Property(p => p.ProductId).ValueGeneratedOnAdd();

            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .IsRequired();

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
