using GranjaDeHuevo.Domain.Entity;

namespace GranjaDeHuevo.Domain.Core
{
    public class BaseAuditory : BaseEntity
    {
        public virtual Users UserCreationNav { get; set; }
        public virtual Users UserModifyNav { get; set; }
        public virtual Users UserDeleteNav { get; set; }
    }
}
