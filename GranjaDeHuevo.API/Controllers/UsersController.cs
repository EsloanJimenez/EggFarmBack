using AutoMapper;
using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasherService _passwordHasherService;
        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, ITokenService tokenService, IPasswordHasherService passwordHasherService, IUsersRepository usersRepository, IMapper mapper)
        {
            _userService = userService;
            _tokenService = tokenService;
            _passwordHasherService = passwordHasherService;
            _userRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = _userService.GetUsers();

                var userDTO = _mapper.Map<IEnumerable<UserDTO>>(users);

                return Ok(userDTO);
            }catch(Exception ex)
            {
                throw new ArgumentException($"Mensaje de error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO userDTO)
        {
            try
            {
                var userN = await _userService.UserNameExists(userDTO.UserName);

                if (userDTO is null)
                    throw new ArgumentException("El permiso no pude ser nulo.");
                else if (userN)
                    return BadRequest("El nombre de usuario ya existe.");

                var users = new Users
                {
                    UserName = userDTO.UserName,
                    PasswordHash = _passwordHasherService.HashPassword(userDTO.PasswordHash),
                    RoleId = userDTO.RoleId,
                    UserCreation = userDTO.UserCreation,
                };

                await _userService.Save(users);

                return Ok(users);
            }catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
        {
            var user = await _userRepository.GetByUserNameAsync(loginDTO.UserName);

            if (user is null || !_passwordHasherService.VerifyPassword(user.PasswordHash, loginDTO.Password))
                return Unauthorized("Usuario o contraseña incorrectos.");

            var token = _tokenService.CreateToken(user);

            var response = new LoginResponseDTO
            {
                Token = token,
                UserId = user.UserId,
                UserRole = user.RoleId,
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(UserDTO userDTO, int Id)
        {
            try
            {
                if (userDTO is null)
                    throw new ArgumentException("El permiso no pude ser nulo.");

                var users = new Users
                {
                    UserId = userDTO.UserId,
                    UserName = userDTO.UserName,
                    PasswordHash = _passwordHasherService.HashPassword(userDTO.PasswordHash),
                    RoleId = userDTO.RoleId,
                    UserModify = userDTO.UserModify
                };

                await _userService.Update(users);

                return Ok(users);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Users user)
        {
            try
            {
                var users = await _userService.GetUserId(user.UserId);

                await _userService.Remove(user);

                return NoContent();
            }catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
