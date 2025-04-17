using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IRoleRepository : IBaseRespository<Role>
    {
        Task<List<RoleDTO>> GetRole();
        Task<RoleDTO> GetRoleById(int id);
    }
}
