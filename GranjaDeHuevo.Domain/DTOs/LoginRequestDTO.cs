using System;
using System.Collections.Generic;
using System.Text;

namespace GranjaDeHuevo.Domain.DTOs
{
    public class LoginRequestDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
