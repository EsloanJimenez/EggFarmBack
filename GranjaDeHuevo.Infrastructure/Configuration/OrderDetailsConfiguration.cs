using GranjaDeHuevo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetails>
    {
        public void Configure(EntityTypeBuilder<OrderDetails> builder)
        {
            builder.HasKey(o => o.OrderDetailId);

            builder.Property(o => o.OrderDetailId).ValueGeneratedOnAdd();

            builder.HasOne(od => od.OrdersNavegation)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(e => e.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(od => od.ProductsNavegation)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull);

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
