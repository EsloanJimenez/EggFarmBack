using System;

namespace GranjaDeHuevo.Domain.Core
{
    public class BaseEntity
    {
        public int UserCreation { get; set; }
        public int? UserModify { get; set; }
        public int? UserDelete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
