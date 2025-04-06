using DevOpsAppData.Entities;
using DevOpsAppManager.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Projects;
using Models.ProjectsTasks;

namespace DevOpsController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectsTasksController : ControllerBase
    {
        public IProjectsTasksManager _manager;

        public ProjectsTasksController(IProjectsTasksManager manager) {
            _manager = manager;
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid taskId) {
            return Ok(await _manager.GetProjectsTaskAsync(taskId));
        }

        [HttpGet("GetAll/{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(Guid projectId)
        {
            return Ok(await _manager.GetAllProjectsTasksAsync(projectId));
        }

        [HttpPost("{projectId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> InsertTask(Guid projectId, ProjectTaskToInsert toInsert)
        {
            return Ok(await _manager.InsertProjectTaskAsync(projectId, toInsert));
        }

        [HttpPut("Update/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateTask(Guid taskId, ProjectTaskToUpdate toUpdate)
        {
            return Ok(await _manager.UpdateProjectTaskAsync(taskId, toUpdate));
        }

        [HttpPut("AlterStatus/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AlterStatus(Guid taskId)
        {
            return Ok(await _manager.AlterProjectTaskStatusAsync(taskId));
        }
    }
}
