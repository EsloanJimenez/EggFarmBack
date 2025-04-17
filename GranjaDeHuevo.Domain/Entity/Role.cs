using GranjaDeHuevo.Domain.Core;

namespace GranjaDeHuevo.Domain.Entity
{
    public class Role : BaseAuditory
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; set; }

    }
}
