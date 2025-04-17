using GranjaDeHuevo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.InventoryId);

            builder.Property(i => i.InventoryId).ValueGeneratedOnAdd();

            builder.Property(i => i.QuantityAdded)
                .IsRequired();

            builder.Property(i => i.Notes)
                .HasMaxLength(200);

            builder.HasOne(i => i.ProductsNavegation)
                .WithMany(ip => ip.Inventory)
                .HasForeignKey(e => e.ProductId);

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
