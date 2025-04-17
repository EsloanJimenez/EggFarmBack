using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IOrdersRepository : IBaseRespository<Orders>
    {
        List<OrdersDTO> GetOrders();
        Task<OrdersDTO> GetOrdersById(int id);
    }
}
