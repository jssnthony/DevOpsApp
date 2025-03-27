using Refit;

namespace DevOpsGateway.SDKs
{
    public interface IProjectApi
    {
        [Get("/Project")]
        Task<string> GetProjects();
    }
}
