using GranjaDeHuevo.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.OrderId).ValueGeneratedOnAdd();

            builder.Property(o => o.TotalAmount).IsRequired();

            builder.Property(o => o.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(o => o.CustomersNavegation)
                .WithMany(co => co.Orders)
                .HasForeignKey(e => e.CustomerId)
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
