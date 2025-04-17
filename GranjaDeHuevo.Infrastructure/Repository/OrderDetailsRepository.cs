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
    public class OrderDetailsRepository : BaseRepository<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(AppGranjaDeHuevoContext context) : base(context)
        {
            
        }

        public List<OrderDetailsDTO> GetOrderDetail()
        {
            return _context.OrderDetails
                .Where(od => od.Deleted == false)
                .Join(_context.Orders,
                    ods => ods.OrderId,
                    or => or.OrderId,
                    (ods, or) => new {ods = ods, or = or})
                .Join(_context.Products,
                    orDt => orDt.ods.ProductId,
                    p => p.ProductId,
                    (orDt, p) => new {orDt = orDt, p = p})
                .Join(_context.Customers,
                    o => o.orDt.or.CustomerId,
                    c => c.CustomerId,
                    (o, c) => new {o = o, c = c})
                .OrderByDescending(od => od.o.orDt.ods.OrderDetailId)
                .Select(od => new OrderDetailsDTO
                {
                    OrderDetailId = od.o.orDt.ods.OrderDetailId,
                    FirstName = od.c.FirstName,
                    Phone = od.c.Phone,
                    Address = od.c.Address,
                    OrderId = od.o.orDt.ods.OrderId,
                    Status = od.o.orDt.or.Status,
                    CreationDate = od.o.orDt.or.CreationDate,
                    ProductName = od.o.p.ProductName,
                    TotalAmount = od.o.orDt.or.TotalAmount,
                    ProductId = od.o.orDt.ods.ProductId,
                    Quantity = od.o.orDt.ods.Quantity,
                    UnitPrice = od.o.orDt.ods.UnitPrice,
                    SubTotal = od.o.orDt.ods.SubTotal,
                }).ToList();
        }

        public async Task<List<OrderDetailsDTO>> GetOrderDetailById(int id)
        {
            return await _context.OrderDetails
                .Where(od => od.Deleted == false && od.OrderId == id)
                .Join(_context.Orders,
                    ods => ods.OrderId,
                    or => or.OrderId,
                    (ods, or) => new { ods = ods, or = or })
                .Join(_context.Products,
                    orDt => orDt.ods.ProductId,
                    p => p.ProductId,
                    (orDt, p) => new { orDt = orDt, p = p })
                .Join(_context.Customers,
                    o => o.orDt.or.CustomerId,
                    c => c.CustomerId,
                    (o, c) => new { o = o, c = c })
                .OrderByDescending(od => od.o.orDt.ods.OrderDetailId)
                .Select(od => new OrderDetailsDTO
                {
                    OrderDetailId = od.o.orDt.ods.OrderDetailId,
                    FirstName = od.c.FirstName,
                    Phone = od.c.Phone,
                    Address = od.c.Address,
                    OrderId = od.o.orDt.ods.OrderId,
                    Status = od.o.orDt.or.Status,
                    CreationDate = od.o.orDt.or.CreationDate,
                    ProductName = od.o.p.ProductName,
                    TotalAmount = od.o.orDt.or.TotalAmount,
                    ProductId = od.o.orDt.ods.ProductId,
                    Quantity = od.o.orDt.ods.Quantity,
                    UnitPrice = od.o.orDt.ods.UnitPrice,
                    SubTotal = od.o.orDt.ods.SubTotal,
                }).ToListAsync();
        }

        public async Task<OrderDetails> GetOrderDetailId(int id)
        {
            return await _context.OrderDetails
                                 .Where(od => od.OrderDetailId == id && !od.Deleted)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<OrderDetails>> GetByOrderId(int orderId)
        {
            return await _context.OrderDetails
                                 .Where(od => od.OrderId == orderId && !od.Deleted)
                                 .ToListAsync();
        }

    }
}
