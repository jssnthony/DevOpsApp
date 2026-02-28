using DevOpsAppManager.Mappers;
using DevOpsAppRepository.InventoryRepository;
using Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOpsAppManager.Inventory
{
    public class InventoryManager : IInventoryManager
    {
        IInventoryRepository _repository;

        public InventoryManager(IInventoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<InventoryDto>> GetAllAsync(string type)
        {
            var inventory = await _repository.GetAllAsync(type);
            return ManagerMappers.Parse(inventory);
        }

        public async Task<bool> InventoryTypeExistsAsync(string type)
        {
            return await _repository.InventoryTypeExistsAsync(type);
        }
    }
}
