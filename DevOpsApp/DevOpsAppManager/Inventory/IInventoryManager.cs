using Models.Inventory;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOpsAppManager.Inventory
{
    public interface IInventoryManager
    {
        /// <summary>
        /// Asynchronously retrieves all inventory items of the specified type.
        /// </summary>
        /// <param name="type">The inventory type to filter the results. This value cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of inventory items
        /// matching the specified type. The collection will be empty if no items are found.</returns>
        Task<IEnumerable<InventoryDto>> GetAllAsync(string type);

        /// <summary>
        /// Asynchronously determines whether an object of the specified type exists.
        /// </summary>
        /// <param name="type">The name of the type to check for existence. Cannot be null or empty.</param>
        /// <returns>A task that represents the asynchronous operation. The task result is <see langword="true"/> if an object of
        /// the specified type exists; otherwise, <see langword="false"/>.</returns>
        Task<bool> InventoryTypeExistsAsync(string type);
    }
}
