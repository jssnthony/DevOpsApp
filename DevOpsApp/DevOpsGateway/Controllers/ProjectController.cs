using DevOpsGateway.SDKs;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;

namespace DevOpsGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectApi _projectApi;

        public ProjectController(IProjectApi projectApi)
        {
            _projectApi = projectApi;
        }

        [HttpGet(Name = "GetProjects")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var projects = await _projectApi.GetProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener proyectos: {ex.Message}");
            }
        }
    }
}