using DevOpsGateway.SDKs;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;

namespace DevOpsGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectApi _projectApi;

        public ProjectsController(IProjectApi projectApi)
        {
            _projectApi = projectApi;
        }


        [HttpGet("stats", Name = "stats")]
        public async Task<IActionResult> StatsProjects()
        {
            try
            {
                return Ok(await _projectApi.CountProjectsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error counting projects: {ex.Message}");
            }
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _projectApi.GetAllProjectsAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving all projects: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _projectApi.GetProjectAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retreiving project: {ex.Message}");
            }
            
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] ProjectDtoToInsert toInsert)
        {
            try
            {
                return Ok(await _projectApi.InsertProjectsAsync(toInsert));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error inserting new project: {ex.Message}");
            }
            
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProjectDtoToUpdate toUpdate)
        {
            try
            {
                if (id != toUpdate.Id)
                    return NotFound("Id does not match");
                return Ok(await _projectApi.UpdateProjectsAsync(id, toUpdate));
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error updating new project: {ex.Message}");
            }
        }

        [HttpDelete("Archive/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Archive(Guid id)
        {
            try
            {
                await _projectApi.ArchiveProjectAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error archinving new project: {ex.Message}");
            } 
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Disable(Guid id)
        {
            try
            {
                await _projectApi.DesactivateProjectAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error archinving new project: {ex.Message}");
            }
        }
    }
}