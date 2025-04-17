using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Repository
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(AppGranjaDeHuevoContext context) : base(context)
        {
            
        }

        public List<InventoryDTO> GetInventories()
        {
            return _context.Inventory
                .Where(i => i.Deleted == false)
                .Join(_context.Products,
                    inv => inv.ProductId,
                    pro => pro.ProductId,
                    (inv, pro) => new {Inventory = inv, Product = pro})
                .OrderByDescending(i => i.Inventory.ProductId)
                .Select(i => new InventoryDTO {
                    InventoryId = i.Inventory.InventoryId,
                    ProductId = i.Inventory.ProductId,
                    QuantityAdded = i.Inventory.QuantityAdded,
                    QuantityAvailable = i.Inventory.QuantityAvailable,
                    Notes = i.Inventory.Notes,
                    ProductName = i.Product.ProductName
                }).ToList();
        }

        public async Task<InventoryDTO> GetInventoryById(int id)
        {
            return await _context.Inventory
                .Where(i => i.Deleted == false && i.ProductId == id)
                .Join(_context.Products,
                    inv => inv.ProductId,
                    pro => pro.ProductId,
                    (inv, pro) => new {inv = inv, pro = pro})
                .OrderByDescending(i => i.inv.InventoryId)
                .Select(i => new InventoryDTO
                {
                    InventoryId = i.inv.InventoryId,
                    ProductId = i.inv.ProductId,
                    QuantityAdded = i.inv.QuantityAdded,
                    QuantityAvailable = i.inv.QuantityAvailable,
                    Notes = i.inv.Notes,
                    ProductName = i.pro.ProductName,
                }).FirstOrDefaultAsync();
        }
    }
}
 