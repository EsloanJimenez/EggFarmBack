using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface ICustomerService : IBaseService<Customers>
    {
        List<CustomersDTO> GetCustomers();
        Task<bool> EmailExists(string email);
        Task<bool> PhoneExists(string phone);
    }
}
