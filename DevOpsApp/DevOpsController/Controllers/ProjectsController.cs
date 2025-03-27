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
        public async Task<IActionResult> Get()
        {
            return Ok(await _manager.GetAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProjectDtoToInsert toInsert)
        {
            return Ok(await _manager.InsertAsync(toInsert));
        }
    }
}