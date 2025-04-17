using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IOrderDetailsRepository : IBaseRespository<OrderDetails>
    {
        List<OrderDetailsDTO> GetOrderDetail();
        Task<OrderDetails> GetOrderDetailId(int id);
        Task<List<OrderDetailsDTO>> GetOrderDetailById(int id);
        Task<List<OrderDetails>> GetByOrderId(int id);
    }
}
