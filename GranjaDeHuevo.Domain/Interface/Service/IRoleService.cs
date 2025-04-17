using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface IRoleService : IBaseService<Role>
    {
        Task<List<RoleDTO>> GetAll();
        Task<RoleDTO> GetRoleById(int id);
    }
}
