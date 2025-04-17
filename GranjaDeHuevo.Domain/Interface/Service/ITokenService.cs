using GranjaDeHuevo.Domain.Entity;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface ITokenService
    {
        string CreateToken(Users users);
    }
}
