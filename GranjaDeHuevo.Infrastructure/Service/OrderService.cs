using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class OrderService : BaseService<Orders>
    {
        private readonly IOrdersRepository _orderRepository;
        private readonly AppGranjaDeHuevoContext _context;
        public OrderService(IOrdersRepository ordersRepository, AppGranjaDeHuevoContext context) : base(ordersRepository, context)
        {
            _orderRepository = ordersRepository;
            _context = context;
        }

        public List<OrdersDTO> GetOrders()
        {
            return _orderRepository.GetOrders();
        }

        public virtual async Task Update(Orders orders)
        {
            Orders orderToUpdate = await _orderRepository.GetId(orders.OrderId);

            orderToUpdate.CustomerId = orders.CustomerId;
            orderToUpdate.TotalAmount = orders.TotalAmount;
            orderToUpdate.Status = orders.Status;

            orderToUpdate.UserModify = orders.UserModify;
            orderToUpdate.ModifyDate = DateTime.Now;

            await base.Update(orderToUpdate);
        }

        public override async Task Remove(Orders orders)
        {
            Orders orderToDelete = await _orderRepository.GetId(orders.OrderId);

            orderToDelete.UserDelete = orders.UserDelete;
            orderToDelete.Deleted = true;
            orderToDelete.DeletedDate = DateTime.Now;

            await base.Update(orderToDelete);
        }
    }
}
