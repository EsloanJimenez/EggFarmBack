using GranjaDeHuevo.Domain.DTOs;
using GranjaDeHuevo.Domain.Entity;
using GranjaDeHuevo.Domain.Interface.Repository;
using GranjaDeHuevo.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GranjaDeHuevo.Infrastructure.Service
{
    public class InventoryService : BaseService<Inventory>
    {
        private readonly IInventoryRepository _InventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository, AppGranjaDeHuevoContext context) : base(inventoryRepository, context)
        {
            _InventoryRepository = inventoryRepository;
        }

        public List<InventoryDTO> GetInventories()
        {
            return _InventoryRepository.GetInventories();
        }

        public async Task<InventoryDTO> GetInventoryId(int id)
        {
            return await _InventoryRepository.GetInventoryById(id);
        }

        public override async Task Update(Inventory inventory)
        {
            Inventory inventoryToUpdate = await _InventoryRepository.GetId(inventory.InventoryId);

            inventoryToUpdate.QuantityAdded = inventory.QuantityAdded;
            inventoryToUpdate.QuantityAvailable = inventory.QuantityAvailable;
            inventoryToUpdate.Notes = inventory.Notes;

            inventoryToUpdate.UserModify = inventory.UserModify;
            inventoryToUpdate.ModifyDate = DateTime.UtcNow;

            await base.Update(inventoryToUpdate);
        }

        public override async Task Remove(Inventory inventory)
        {
            Inventory inventoryToDelete = await _InventoryRepository.GetId(inventory.InventoryId);

            inventoryToDelete.UserDelete = inventory.UserDelete;
            inventoryToDelete.Deleted = true;
            inventoryToDelete.DeletedDate = DateTime.UtcNow;

            await base.Update(inventoryToDelete);
        }
    }
}
