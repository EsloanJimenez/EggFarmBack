using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Domain.Interface.Service;
using GranjaDeHuevo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository respository, AppGranjaDeHuevoContext context) : base(respository, context)
        {
            _roleRepository = respository;
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            return await _roleRepository.GetRole();
        }

        public async Task<RoleDTO> GetRoleById(int id)
        {
            return await _roleRepository.GetRoleById(id);
        }

        public override async Task Update(Role role)
        {
            var roleToUpdate = await _roleRepository.GetId(role.RoleId);

            roleToUpdate.RoleName = role.RoleName;
            roleToUpdate.Description = role.Description;

            roleToUpdate.UserModify = role.UserModify;
            roleToUpdate.ModifyDate = DateTime.Now;

            await base.Update(roleToUpdate);
        }

        public virtual async Task Remove(Role role)
        {
            var roleToDelete = await _roleRepository.GetId(role.RoleId);

            roleToDelete.Deleted = true;
            roleToDelete.UserDelete = role.UserDelete;
            roleToDelete.DeletedDate = DateTime.Now;

            await base.Update(roleToDelete);
        }
    }
}
