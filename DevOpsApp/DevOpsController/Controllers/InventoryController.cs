using Microsoft.AspNetCore.Mvc;
using Models.Inventory;

namespace DevOpsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController
    {
        [HttpGet("{type}", Name = "GetAll")]
        public async Task<IActionResult> GetAll(string type) {
            return new JsonResult(new List<string>() { "TCG1", "TCG2", "TCG3" });
        }

        //[HttpGet("{type}", Name = "GetAll")]
        //public async Task<IActionResult> GetAll(string type)
        //{
        //    if (string.IsNullOrWhiteSpace(type))
        //        return BadRequest("Inventory type is required.");

        //    var validTypes = await _inventoryTypeService.ExistsAsync(type);

        //    if (!validTypes)
        //        return NotFound($"Inventory type '{type}' is not supported.");

        //    var result = await _inventoryApi.GetAllAsync(type);
        //    return Ok(result);
        //}
    }
}
