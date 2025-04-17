using AutoMapper;
using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using GranjaDeHuevo.Domain.Interface.Service;

namespace GranjaDeHuevo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        
            private readonly IProductService _productService;
            private readonly IMapper _mapper;
            public ProductsController(IProductService productService, IMapper mapper)
            {
                _productService = productService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IActionResult> Get()
            {
                try
                {
                    var products = _productService.GetProducts();

                    var productsDTO = _mapper.Map<IEnumerable<ProductsDTO>>(products);

                    return Ok(productsDTO);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost]
            public async Task<IActionResult> Post(ProductsDTO productsDTO)
            {
                try
                {
                    if (productsDTO is null)
                        return BadRequest(new { message = "El producto no puede ser nula." });

                    var products = new Products
                    {
                        ProductName = productsDTO.ProductName,
                        Description = productsDTO.Description,
                        Price = productsDTO.Price,
                        UserCreation = productsDTO.UserCreation,
                    };

                    await _productService.Save(products);

                    return Ok(products);
                }
                catch (Exception ex)
                {
                    return BadRequest(new {message = "error pero porque: " + ex.Message});
                }
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Put(ProductsDTO productsDTO, int id)
            {
                try
                {
                if (productsDTO is null)
                    throw new ArgumentNullException("El producto no puede ser nula.");

                var products = new Products
                {
                    ProductId = productsDTO.ProductId,
                    ProductName = productsDTO.ProductName,
                    Description = productsDTO.Description,
                    Price = productsDTO.Price,
                    UserModify = productsDTO.UserModify
                };

                await _productService.Update(products);

                return Ok(products);
            }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Remove([FromBody] Products products)
            {
                try
                {
                    await _productService.Remove(products);

                    return NoContent();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
        
    }
}
