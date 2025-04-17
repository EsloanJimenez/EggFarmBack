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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var role = await _roleService.GetAll();
                var roleDTO = _mapper.Map<IEnumerable<RoleDTO>>(role);

                return Ok(roleDTO);
            }catch(ArgumentException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
    }
}
