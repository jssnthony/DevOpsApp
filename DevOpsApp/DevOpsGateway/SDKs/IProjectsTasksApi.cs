using Microsoft.AspNetCore.Mvc;
using Models.Projects;
using Models.ProjectsTasks;
using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IProjectsTasksApi
    {
        [Get("/ProjectsTasks/{taskId}")]
        Task<ViewTaskProjectDto> GetProjectsTaskAsync(Guid taskId);

        [Get("/ProjectsTasks/GetAll/{projectId}")]
        Task<IEnumerable<ViewTaskProjectDto>> GetAllProjectsTasksAsync(Guid projectId);

        [Post("/ProjectsTasks/{projectId}")]
        Task<ViewTaskProjectDto> InsertProjectTaskAsync(Guid projectId, ProjectTaskToInsert toInsert);

        [Put("/ProjectsTasks/Update/{taskId}")]
        Task<ViewTaskProjectDto?> UpdateProjectTaskAsync(Guid taskId, ProjectTaskToUpdate toUpdate);

        [Put("/ProjectsTasks/AlterStatus/{taskId}")]
        Task<bool> AlterProjectTaskStatusAsync(Guid taskId);

        [Get("/ProjectsTasks/")]
        Task<IEnumerable<ViewTaskProjectDto>> GetAllTasksAsync();
    }
}
