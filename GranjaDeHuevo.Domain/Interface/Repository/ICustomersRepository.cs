using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface ICustomersRepository : IBaseRespository<Customers>
    {
        List<CustomersDTO> GetCustomers();
        Task<CustomersDTO> GetCustomersById(int id);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> PhoneExistsAsync(string phone);
    }
}
