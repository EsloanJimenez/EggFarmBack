using AutoMapper;
using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Service;
using GranjaDeHuevo.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailsService;
        private readonly IMapper _mapper;

        public OrderDetailsController(IOrderDetailService orderDetailsService, IMapper mapper)
        {
            _orderDetailsService = orderDetailsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var orderDetails = _orderDetailsService.GetOrderDetails();

                var deliveriesDTOs = _mapper.Map<IEnumerable<OrderDetailsDTO>>(orderDetails);

                return Ok(deliveriesDTOs);
            }catch(Exception ex)
            {
                throw new ArgumentException($"Mensaje de error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var orderDetailId = await _orderDetailsService.GetOrderDetailsId(id);
                var orderDetailIdDTO = _mapper.Map<IEnumerable<OrderDetailsDTO>>(orderDetailId);

                return Ok(orderDetailIdDTO);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderDetailsDTO orderDetailsDTO)
        {
            try
            {
                if (orderDetailsDTO is null)
                    throw new ArgumentNullException("Los detalles de la orden no pueden ser nulos.");

                var orderDetails = new OrderDetails
                {
                    OrderId = orderDetailsDTO.OrderId,
                    ProductId = orderDetailsDTO.ProductId,
                    Quantity = orderDetailsDTO.Quantity,
                    UnitPrice = orderDetailsDTO.UnitPrice,
                    SubTotal = orderDetailsDTO.SubTotal,
                    UserCreation = orderDetailsDTO.UserCreation,
                };

                await _orderDetailsService.Save(orderDetails);

                return Ok(orderDetails);

            }catch( Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updated(OrderDetailsDTO orderDetailsDTO, int id)
        {
            try
            {
                if (orderDetailsDTO is null)
                    throw new ArgumentNullException("Los detalles de la orden no pueden ser nulos.");

                var orderDetails = new OrderDetails
                {
                    OrderDetailId = orderDetailsDTO.OrderDetailId,
                    OrderId = orderDetailsDTO.OrderId,
                    ProductId = orderDetailsDTO.ProductId,
                    Quantity = orderDetailsDTO.Quantity,
                    UnitPrice = orderDetailsDTO.UnitPrice,
                    SubTotal = orderDetailsDTO.SubTotal,
                    UserModify = orderDetailsDTO.UserModify,
                };

                await _orderDetailsService.Update(orderDetails);

                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(OrderDetails orderDetail)
        {
            try
            {
                await _orderDetailsService.Remove(orderDetail);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
