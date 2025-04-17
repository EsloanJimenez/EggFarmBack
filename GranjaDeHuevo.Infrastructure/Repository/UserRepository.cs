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
    public class UserRepository : BaseRepository<Users>, IUsersRepository
    {
        public UserRepository(AppGranjaDeHuevoContext context) : base(context)
        {
            
        }

        public List<UserDTO> GetUsers()
        {
            var users = _context.Users
                .Where(u => u.Deleted == false)
                .Join(_context.Role,
                    u => u.RoleId,
                    r => r.RoleId,
                    (u, r) => new {u = u, r = r})
                .OrderByDescending(u => u.u.UserId)
                .Select(u => new UserDTO
                {
                    UserId = u.u.UserId,
                    UserName = u.u.UserName,
                    PasswordHash = u.u.PasswordHash,
                    RoleId = u.u.RoleId,
                    RoleName = u.r.RoleName,
                }).ToList();

            return users;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            return await _context.Users
                .Where(u => !u.Deleted && u.UserId == id)
                .OrderByDescending(u => u.UserId)
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    PasswordHash = u.PasswordHash,
                    RoleId = u.RoleId
                }).FirstOrDefaultAsync();
        }

        public async Task<Users> GetByUserNameAsync(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && !u.Deleted);
        }

        public async Task<bool> ExistsUserNameAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.UserName == username && !u.Deleted);
        }
    }
}
