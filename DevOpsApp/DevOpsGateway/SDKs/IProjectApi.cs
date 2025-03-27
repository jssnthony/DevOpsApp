using Models.Projects;
using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IProjectApi
    {
        [Get("/Projects")]
        Task<string> GetProjects();

        [Post("/Projects")]
        Task<Guid> InsertProjects(ProjectDtoToInsert projectDtoToInsert);
    }
}
