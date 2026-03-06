using DevOpsGateway.SDKs;
using Microsoft.AspNetCore.Mvc;
using Models.ProjectsTasks;

namespace DevOpsGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsTasksController : ControllerBase
    {
        private readonly IProjectsTasksApi _projectApi;

        public ProjectsTasksController(IProjectsTasksApi projectApi) {
            _projectApi = projectApi;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(await _projectApi.GetAllTasksAsync());
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid taskId)
        {
            return Ok(await _projectApi.GetProjectsTaskAsync(taskId));
        }

        [HttpGet("GetAll/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(Guid projectId)
        {
            return Ok(await _projectApi.GetAllProjectsTasksAsync(projectId));
        }

        [HttpPost("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertTask(Guid projectId, ProjectTaskToInsert toInsert)
        {
            return Ok(await _projectApi.InsertProjectTaskAsync(projectId, toInsert));
        }

        [HttpPut("Update/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTask(Guid taskId, ProjectTaskToUpdate toUpdate)
        {
            return Ok(await _projectApi.UpdateProjectTaskAsync(taskId, toUpdate));
        }

        [HttpPut("AlterStatus/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AlterStatus(Guid taskId)
        {
            return Ok(await _projectApi.AlterProjectTaskStatusAsync(taskId)); 
        }
    }
}
