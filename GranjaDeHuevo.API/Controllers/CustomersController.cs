using AutoMapper;
using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customersService;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customersService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var customer = _customersService.GetCustomers();

                var customerDTO = _mapper.Map<IEnumerable<CustomersDTO>>(customer);

                return Ok(customer);
            }catch(Exception ex)
            {
                throw new ArgumentException($"Mensaje de error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CustomersDTO customersDTO)
        {
            try
            {
                var cusEmail = await _customersService.EmailExists(customersDTO.Email);
                var cusPhone = await _customersService.PhoneExists(customersDTO.Phone);
                
                if (customersDTO is null)
                    throw new ArgumentNullException("El cliente no puede ser nulo.");
                else if (cusEmail)
                    return BadRequest("El Email ya existe.");
                else if (cusPhone)
                    return BadRequest("El telefono ya existe.");


                var customers = new Customers
                {
                    FirstName = customersDTO.FirstName,
                    LastName = customersDTO.LastName,
                    Email = customersDTO.Email,
                    Phone = customersDTO.Phone,
                    Address = customersDTO.Address,
                    UserCreation = customersDTO.UserCreation,
                };

                await _customersService.Save(customers);

                return Ok(customers);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CustomersDTO customersDTO, int id)
        {
            try
            {
                if (customersDTO is null)
                    throw new ArgumentNullException("El cliente no puede ser nulo.");

                var customers = new Customers
                {
                    CustomerId = id,
                    FirstName = customersDTO.FirstName,
                    LastName = customersDTO.LastName,
                    Email = customersDTO.Email,
                    Phone = customersDTO.Phone,
                    Address = customersDTO.Address,
                    UserModify = customersDTO.UserModify,
                };

                await _customersService.Update(customers);

                return Ok(customers);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove([FromBody] Customers customers)
        {
            try
            {
                await _customersService.Remove(customers);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}