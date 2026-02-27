using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IInventoryApi
    {
        [Get("/Inventory/{inventoryType}")]
        Task<object> GetAllAsync(string inventoryType);
    }
}
