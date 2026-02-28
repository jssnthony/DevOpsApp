using DevOpsAppManager.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ControllerBase
    {
        IInventoryManager _inventoryApi;

        public InventoryController(IInventoryManager inventoryApi)
        {
            _inventoryApi = inventoryApi;
        }

        [HttpGet("{type}", Name = "GetAll")]
        public async Task<IActionResult> GetAll(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                return BadRequest("Inventory type is required.");

            var validTypes = await _inventoryApi.InventoryTypeExistsAsync(type);

            if (!validTypes)
                return NotFound($"Inventory type '{type}' is not supported.");

            var result = await _inventoryApi.GetAllAsync(type);
            return Ok(result);
        }
    }
}
