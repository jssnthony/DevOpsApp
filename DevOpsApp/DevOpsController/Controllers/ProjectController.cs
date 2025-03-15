using Microsoft.AspNetCore.Mvc;
using Models.Projects;

namespace DevOpsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProjects")]
        public IEnumerable<ProjectsResultDto> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ProjectsResultDto
            {
                Description = $"{index}",
                Id = new Guid(),
                Name = "test",
                Repository = "test repository"
            })
            .ToArray();
        }
    }
}