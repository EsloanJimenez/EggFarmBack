using GranjaDeHuevo.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GranjaDeHuevo.Infrastructure.Configuration
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(e => e.UserCreation)
                .IsRequired();

            builder.Property(e => e.CreationDate)
                .IsRequired()
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(e => e.UserModify)
                .IsRequired(false);

            builder.Property(e => e.ModifyDate)
                .IsRequired(false);

            builder.Property(e => e.UserDelete)
                .IsRequired(false);

            builder.Property(e => e.DeletedDate)
                .IsRequired(false);

            builder.Property(e => e.Deleted)
                .HasDefaultValue(false);
        }
    }
}
