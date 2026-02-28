using Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOpsAppRepository.InventoryRepository
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryBaseModel>> GetAllAsync(string type);

        Task<bool> InventoryTypeExistsAsync(string type);
    }
}
