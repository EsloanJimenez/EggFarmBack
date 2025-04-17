using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface IOrderDetailService : IBaseService<OrderDetails>
    {
        List<OrderDetailsDTO> GetOrderDetails();
        Task<List<OrderDetailsDTO>> GetOrderDetailsId(int id);
    }
}
