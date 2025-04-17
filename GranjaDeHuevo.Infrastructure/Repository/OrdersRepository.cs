using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Repository
{
    public class OrdersRepository : BaseRepository<Orders>, IOrdersRepository
    {
        public OrdersRepository(AppGranjaDeHuevoContext context) : base(context)
        {
            
        }

        public List<OrdersDTO> GetOrders()
        {
            return _context.Orders
                        .Where(o => o.Deleted == false)
                        .Join(_context.Customers,
                            or => or.CustomerId,
                            cus => cus.CustomerId,
                            (or, cus) => new {or = or, cus = cus})
                        .OrderByDescending(o => o.or.OrderId)
                        .Select(o => new OrdersDTO
                        {
                            OrderId = o.or.OrderId,
                            CustomerId = o.or.CustomerId,
                            TotalAmount = o.or.TotalAmount,
                            Status = o.or.Status,
                            FirstName = o.cus.FirstName
                        }).ToList();
        }

        public async Task<OrdersDTO> GetOrdersById(int id)
        {
            return await _context.Orders
                .Where(o => !o.Deleted && o.OrderId == id)
                .Join(_context.Customers,
                    or => or.CustomerId,
                    cus => cus.CustomerId,
                    (or, cus) => new {or = or, cus = cus})
                .OrderByDescending (o => o.or.OrderId)
                .Select(o => new OrdersDTO
                {
                    OrderId = o.or.OrderId,
                    CustomerId = o.or.CustomerId,
                    TotalAmount = o.or.TotalAmount,
                    Status = o.or.Status,
                    FirstName = o.cus.FirstName
                }).FirstOrDefaultAsync();
        }
    }
}
