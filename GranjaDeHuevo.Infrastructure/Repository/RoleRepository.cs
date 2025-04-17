using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(AppGranjaDeHuevoContext context) : base(context)
        {
        }

        public async Task<List<RoleDTO>> GetRole()
        {
            return await _context.Role
                .Where(r => !r.Deleted)
                .OrderByDescending(r => r.RoleId)
                .Select(r => new RoleDTO
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName,
                    Description = r.Description,
                }).ToListAsync();
        }

        public async Task<RoleDTO> GetRoleById(int id)
        {
            return await _context.Role
                .Where(r => !r.Deleted && r.RoleId == id)
                .OrderByDescending (r => r.RoleId)
                .Select(r => new RoleDTO
                {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName,
                    Description = r.Description,
                }).FirstOrDefaultAsync();
        }
    }
}
