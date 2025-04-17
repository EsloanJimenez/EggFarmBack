using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class UserService : BaseService<Users>
    {
        private readonly IUsersRepository _usersRepository;
        private readonly AppGranjaDeHuevoContext _context;

        public UserService(IUsersRepository usersRepository, AppGranjaDeHuevoContext context) : base(usersRepository, context)
        {
            _usersRepository = usersRepository;
            _context = context;
        }

        public List<UserDTO> GetUsers()
        {
            return _usersRepository.GetUsers();
        }

        public Task<UserDTO> GetUserId(int id)
        {
            return _usersRepository.GetUserById(id);
        }

        public override async Task Update(Users users)
        {
            Users UserToUpdate = await _usersRepository.GetId(users.UserId);

            UserToUpdate.UserName = users.UserName;
            UserToUpdate.PasswordHash = users.PasswordHash;
            UserToUpdate.RoleId = users.RoleId;

            UserToUpdate.UserModify = users.UserModify;
            UserToUpdate.ModifyDate = DateTime.UtcNow;

            await base.Update(UserToUpdate);
        }

        public override async Task Remove(Users user)
        {
            Users userToDelete = await _usersRepository.GetId(user.UserId);

            userToDelete.UserDelete = user.UserDelete;
            userToDelete.Deleted = true;
            userToDelete.DeletedDate = DateTime.UtcNow;

            await base.Update(userToDelete);
        }

        public async Task<bool> UserNameExists(string username)
        {
            return await _usersRepository.ExistsAsync(u => u.UserName == username);
        }
    }
}
