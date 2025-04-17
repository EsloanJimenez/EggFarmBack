using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IUsersRepository : IBaseRespository<Users>
    {
        List<UserDTO> GetUsers();

        Task<UserDTO> GetUserById(int id);
        Task<Users> GetByUserNameAsync(string userName);
        Task<bool> ExistsUserNameAsync(string userName);
    }
}
