using DevOpsAppData.Models;
using Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOpsAppRepository.InventoryRepository
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly DevOpsAppContext _context;

        public InventoryRepository(DevOpsAppContext ctx)
        {
            _context = ctx;
        }

        public Task<IEnumerable<InventoryBaseModel>> GetAllAsync(string type)
        {
            return new Task<IEnumerable<InventoryBaseModel>>(() => _context.Inventories.Where(i => ValidateCategory(i.Category.CategoryName, type)).Select(i => new InventoryBaseModel
            {
                KeyId = i.Id,
                InventoryId = i.UniqueKey,
                InventoryCategoryDetails = i.Category.CategoryName,
                Quantity = i.Quantity
            }).ToList());
        }

        public Task<bool> InventoryTypeExistsAsync(string type)
        {
           return new Task<bool>(() => _context.Inventories.Any(i => ValidateCategory(i.Category.CategoryName, type)));
        }

        private bool ValidateCategory(string? expected, string current)
        {
            return expected.ToLower() == current.ToLower();
        }
    }
}
