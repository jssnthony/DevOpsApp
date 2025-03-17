using DevOpsAppManager.Projects;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;

namespace DevOpsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;
        private readonly IProjectsManager _manager;

        public ProjectController(ILogger<ProjectController> logger, IProjectsManager projectsManager)
        {
            _logger = logger;
            _manager = projectsManager;
        }

        [HttpGet(Name = "GetProjects")]
        public async Task<IEnumerable<ProjectsResultDto>> Get()
        {
            return await _manager.GetProjectsAsync();
        }
    }
}