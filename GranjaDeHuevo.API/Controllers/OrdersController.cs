using AutoMapper;
using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Service;
using GranjaDeHuevo.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var Orders = _orderService.GetOrders();

                var OrdersDTO = _mapper.Map<IEnumerable<OrdersDTO>>(Orders);

                return Ok(OrdersDTO);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrdersDTO ordersDTO)
        {
            try
            {
                if(ordersDTO is null)
                    throw new ArgumentNullException("La orden no puede ser nula.");

                var orders = new Orders
                {
                    CustomerId = ordersDTO.CustomerId,
                    TotalAmount = ordersDTO.TotalAmount,
                    Status = ordersDTO.Status,
                    UserCreation = ordersDTO.UserCreation,
                };

                await _orderService.Save(orders);

                return Ok(orders);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(OrdersDTO ordersDTO, int id)
        {
            try
            {
                if (ordersDTO is null)
                    throw new ArgumentNullException("La orden no puede ser nula.");

                var orders = new Orders
                {
                    OrderId = ordersDTO.OrderId,
                    CustomerId = ordersDTO.CustomerId,
                    TotalAmount = ordersDTO.TotalAmount,
                    Status = ordersDTO.Status,
                    UserModify = ordersDTO.UserModify,
                };

                await _orderService.Update(orders);

                return Ok(orders);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Orders orders)
        {
            try
            {
                await _orderService.Remove(orders);

                return NoContent();
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
