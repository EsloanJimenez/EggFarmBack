using GranjaDeHuevo.Domain.Core;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace GranjaDeHuevo.Infrastructure.Context
{
    public class AppGranjaDeHuevoContext : DbContext
    {
        public AppGranjaDeHuevoContext(DbContextOptions<AppGranjaDeHuevoContext> op) : base(op)
        {
            
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new InventoryConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            // Aplicar automáticamente la configuración a todas las entidades que hereden de BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseEntity).IsAssignableFrom(e.ClrType)))
            {
                var configType = typeof(BaseEntityConfiguration<>).MakeGenericType(entityType.ClrType);
                var configInstance = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration((dynamic)configInstance);
            }

            // Aplicar automáticamente la configuración a todas las entidades que hereden de BaseStatus
            foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                .Where(e => typeof(BaseStatus).IsAssignableFrom(e.ClrType)))
            {
                var configType = typeof(BaseStatusConfiguration<>).MakeGenericType(entityType.ClrType);
                var configInstance = Activator.CreateInstance(configType);
                modelBuilder.ApplyConfiguration((dynamic)configInstance);
            }
        }
    }
}
