using GranjaDeHuevo.Domain.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class BaseStatusConfiguration<TEntity> : BaseEntityConfiguration<TEntity> where TEntity :BaseStatus
    {
        public new void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
