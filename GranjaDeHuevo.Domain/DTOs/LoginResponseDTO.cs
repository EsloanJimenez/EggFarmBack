using System;
using System.Collections.Generic;
using System.Text;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public int UserId { get; set; }
        public int UserRole { get; set; }
    }
}
