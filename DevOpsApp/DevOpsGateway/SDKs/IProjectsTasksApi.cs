using Microsoft.AspNetCore.Mvc;
using Models.Projects;
using Models.ProjectsTasks;
using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IProjectsTasksApi
    {
        [Get("/ProjectsTasks/{taskId}")]
        Task<ViewProjectTaskDto> GetProjectsTaskAsync(Guid taskId);

        [Get("/ProjectsTasks/GetAll/{projectId}")]
        Task<IEnumerable<ViewProjectTaskDto>> GetAllProjectsTasksAsync(Guid projectId);

        [Post("/ProjectsTasks/{projectId}")]
        Task<ViewProjectTaskDto> InsertProjectTaskAsync(Guid projectId, ProjectTaskToInsert toInsert);

        [Put("/ProjectsTasks/Update/{taskId}")]
        Task<ViewProjectTaskDto?> UpdateProjectTaskAsync(Guid taskId, ProjectTaskToUpdate toUpdate);

        [Put("/ProjectsTasks/AlterStatus/{taskId}")]
        Task<bool> AlterProjectTaskStatusAsync(Guid taskId);

    }
}
