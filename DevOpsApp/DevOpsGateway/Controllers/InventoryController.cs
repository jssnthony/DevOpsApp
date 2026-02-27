using DevOpsGateway.SDKs;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        IInventoryApi _inventoryApi;

        public InventoryController(IInventoryApi inventoryApi)
        {
            _inventoryApi = inventoryApi;
        }

        [HttpGet("{inventoryType}", Name = "GetAllItems")]
        public async Task<IActionResult> GetAll(string inventoryType)
        {
            try
            {
                return Ok(await _inventoryApi.GetAllAsync(inventoryType));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retreiving inventory: {ex.Message}");
            }
        }
    }
}
