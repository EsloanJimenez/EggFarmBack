using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Domain.Interface.Service
{
    public interface IInventoryService : IBaseService<Inventory>
    {
        List<InventoryDTO> GetInventories();
        Task<InventoryDTO> GetInventoryId(int id);
    }
}
