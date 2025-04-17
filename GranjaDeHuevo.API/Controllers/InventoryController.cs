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
    public class InventoryController : Controller
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var inventory = _inventoryService.GetInventories();

                var inventoryDTO = _mapper.Map<IEnumerable<InventoryDTO>>(inventory);

                return Ok(inventoryDTO);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var inventoryId = await _inventoryService.GetInventoryId(id);

                if(inventoryId is null)
                {
                    var inventorybyId = new Inventory
                    {
                        QuantityAvailable = 0
                    };

                    return Ok(inventorybyId);
                }

                var inventoryIdDTO = _mapper.Map<InventoryDTO>(inventoryId);
                return Ok(inventoryIdDTO);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(InventoryDTO inventoryDTO)
        {
            try
            {
                if (inventoryDTO is null)
                    throw new ArgumentException("El inventario no puede ser nulo.");

                var inventory = new Inventory
                {
                    ProductId = inventoryDTO.ProductId,
                    QuantityAdded = inventoryDTO.QuantityAdded,
                    QuantityAvailable = inventoryDTO.QuantityAvailable,
                    Notes = inventoryDTO.Notes,
                    UserCreation = inventoryDTO.UserCreation,
                };

                await _inventoryService.Save(inventory);

                return Ok(inventory);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(InventoryDTO inventoryDTO, int id)
        {
            try
            {
                if (inventoryDTO is null)
                    throw new ArgumentException("El inventario no puede ser nulo.");

                var inventory = new Inventory
                {
                    InventoryId = inventoryDTO.InventoryId,
                    ProductId = inventoryDTO.ProductId,
                    QuantityAdded = inventoryDTO.QuantityAdded,
                    QuantityAvailable = inventoryDTO.QuantityAvailable,
                    Notes = inventoryDTO.Notes,
                    UserModify = inventoryDTO.UserModify,
                };

                await _inventoryService.Update(inventory);

                return Ok(inventory);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Inventory inventory)
        {
            try
            {
                await _inventoryService.Remove(inventory);

                return NoContent();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
