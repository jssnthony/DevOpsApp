using Microsoft.AspNetCore.Mvc;
using Models.Projects;

namespace DevOpsGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        [HttpGet(Name = "GetProject")]
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