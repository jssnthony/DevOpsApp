using Models.Projects;
using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IProjectApi
    {
        [Get("/Projects")]
        Task<IEnumerable<ProjectsResultDto?>> GetAllProjectsAsync();

        [Get("/Projects/{id}")]
        Task<ProjectsResultDto?> GetProjectAsync(Guid id);

        [Post("/Projects")]
        Task<Guid> InsertProjectsAsync(ProjectDtoToInsert projectDtoToInsert);

        [Put("/Projects/{id}")]
        Task<Guid> UpdateProjectsAsync(Guid id, ProjectDtoToUpdate projectDtoToInsert);

        [Delete("/Projects/Archive/{id}")]
        Task ArchiveProjectAsync(Guid id);

        [Delete("/Projects/Delete/{id}")]
        Task DesactivateProjectAsync(Guid id);
    }
}
