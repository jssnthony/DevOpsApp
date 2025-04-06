using DevOpsAppManager.Projects;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;

namespace DevOpsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;
        private readonly IProjectsManager _manager;

        public ProjectsController(ILogger<ProjectsController> logger, IProjectsManager projectsManager)
        {
            _logger = logger;
            _manager = projectsManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _manager.GetAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _manager.GetAsync(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert([FromBody] ProjectDtoToInsert toInsert)
        {
            return Ok(await _manager.InsertAsync(toInsert));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProjectDtoToUpdate toUpdate)
        {
            if (id == toUpdate.Id)
                return Ok(await _manager.UpdateAsync(id, toUpdate));
            return NotFound(id);
        }

        [HttpDelete("Archive/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Archive(Guid id)
        {
            if (await _manager.ArchiveRecordAsync(id))
                return Ok();
            return NotFound(id);
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Disable(Guid id)
        {
            if (await _manager.DisableRecordAsync(id))
                return Ok();
            return NotFound(id);
        }
    }
}