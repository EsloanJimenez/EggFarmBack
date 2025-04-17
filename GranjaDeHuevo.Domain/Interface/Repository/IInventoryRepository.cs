using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Repository
{
    public interface IInventoryRepository : IBaseRespository<Inventory>
    {
        List<InventoryDTO> GetInventories();
        Task<InventoryDTO> GetInventoryById(int id);
    }
}
