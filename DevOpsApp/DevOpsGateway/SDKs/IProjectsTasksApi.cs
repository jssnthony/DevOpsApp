using Microsoft.AspNetCore.Mvc;
using Models.Projects;
using Models.ProjectsTasks;
using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IProjectsTasksApi
    {
        [Get("/ProjectsTasks/{taskId}")]
        Task<ProjectsTasksResultDto> GetProjectsTaskAsync(Guid taskId);

        [Get("/ProjectsTasks/GetAll/{projectId}")]
        Task<IEnumerable<ProjectsTasksResultDto>> GetAllProjectsTasksAsync(Guid projectId);

        [Post("/ProjectsTasks/{projectId}")]
        Task<ProjectsTasksResultDto> InsertProjectTaskAsync(Guid projectId, ProjectTaskToInsert toInsert);

        [Put("/ProjectsTasks/Update/{taskId}")]
        Task<ProjectsTasksResultDto?> UpdateProjectTaskAsync(Guid taskId, ProjectTaskToUpdate toUpdate);

        [Put("/ProjectsTasks/AlterStatus/{taskId}")]
        Task<bool> AlterProjectTaskStatusAsync(Guid taskId);

    }
}
