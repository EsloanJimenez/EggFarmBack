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
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(AppGranjaDeHuevoContext context) : base(context)
        {
            
        }

        public List<ProductsDTO> GetProducts()
        {
            return _context.Products
                .Where(p => p.Deleted == false)
                .OrderByDescending(p => p.ProductId)
                .Select(p => new ProductsDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                }).ToList();
        }

        public async Task<ProductsDTO> GetProductsById(int id)
        {
            return await _context.Products
                .Where(p => !p.Deleted && p.ProductId == id)
                .OrderByDescending(p => p.ProductId)
                .Select(p => new ProductsDTO
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    Description = p.Description,
                    Price = p.Price,
                }).FirstOrDefaultAsync();
        }
    }
}
