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

        [HttpGet]
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

        [HttpPost]
        public async Task<IActionResult> Insert(ProjectDtoToInsert projectDtoToInsert)
        {
            try
            {
                return Ok(await _projectApi.InsertProjects(projectDtoToInsert));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar proyectos: {ex.Message}");
            }
        }
    }
}