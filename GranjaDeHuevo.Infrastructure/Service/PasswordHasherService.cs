using GranjaDeHuevo.Domain.Interface.Service;
using Microsoft.AspNetCore.Identity;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private readonly PasswordHasher<string> _hasher = new PasswordHasher<string>();

        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
