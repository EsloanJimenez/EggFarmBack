using GranjaDeHuevo.Domain.Core;

namespace GranjaDeHuevo.Domain.Entity
{
    public class Users : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
    }
}
