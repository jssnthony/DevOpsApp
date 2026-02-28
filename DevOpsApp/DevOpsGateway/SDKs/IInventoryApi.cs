using Models.Inventory;
using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IInventoryApi
    {
        [Get("/Inventory/{inventoryType}")]
        Task<IEnumerable<InventoryDto>> GetAllAsync(string inventoryType);
    }
}
