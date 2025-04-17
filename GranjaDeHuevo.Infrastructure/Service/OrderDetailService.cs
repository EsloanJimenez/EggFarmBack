using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class OrderDetailService : BaseService<OrderDetails>
    {
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly AppGranjaDeHuevoContext _context;
        public OrderDetailService(IOrderDetailsRepository orderDetailsRepository, AppGranjaDeHuevoContext context) : base(orderDetailsRepository, context)
        {
            _orderDetailsRepository = orderDetailsRepository;
            _context = context;
        }

        public List<OrderDetailsDTO> GetOrderDetails()
        {
            return _orderDetailsRepository.GetOrderDetail();
        }

        public async Task<List<OrderDetailsDTO>> GetOrderDetailsId(int id)
        {
            return await _orderDetailsRepository.GetOrderDetailById(id);
        }

        public override async Task Update(OrderDetails orderDetails)
        {
            OrderDetails orderDetailsToUpdate = await _orderDetailsRepository.GetId(orderDetails.OrderDetailId);

            orderDetailsToUpdate.OrderId = orderDetails.OrderId;
            orderDetailsToUpdate.ProductId = orderDetails.ProductId;
            orderDetailsToUpdate.Quantity = orderDetails.Quantity;
            orderDetailsToUpdate.UnitPrice = orderDetails.UnitPrice;
            orderDetailsToUpdate.SubTotal = orderDetails.SubTotal;

            orderDetailsToUpdate.UserModify = orderDetails.UserModify;
            orderDetailsToUpdate.ModifyDate = DateTime.Now;

            await base.Update(orderDetailsToUpdate);
        }

        public override async Task Remove(OrderDetails orderDetails)
        {
            var orderDetailsToDelted = await _orderDetailsRepository.GetOrderDetailId(orderDetails.OrderDetailId);

            /*
            foreach (var detail in orderDetailsToDelted)
            {
                detail.UserDelete = orderDetails.UserDelete;
                detail.Deleted = true;
                detail.DeletedDate = DateTime.Now;
                await base.Update(detail); // o acumular todos y guardar al final
            }
            */
            orderDetailsToDelted.UserDelete = orderDetails.UserDelete;
            orderDetailsToDelted.Deleted = true;
            orderDetailsToDelted.DeletedDate = DateTime.Now;
            await base.Update(orderDetailsToDelted);
        }
    }
}
