using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface IUserService : IBaseService<Users>
    {
        List<UserDTO> GetUsers();
        Task<UserDTO> GetUserId(int id);
        Task<bool> UserNameExists(string name);
    }
}
