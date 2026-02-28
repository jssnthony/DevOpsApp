using Models.Projects;

namespace DevOpsAppManager.Projects
{
    public interface IProjectsManager
    {
        Task<bool> ArchiveRecordAsync(Guid id);
        Task<ProjectStats> GetStatsProjectsAsync();
        Task<bool> DisableRecordAsync(Guid id);
        public Task<IEnumerable<ProjectsResultDto>> GetAsync();
        Task<ProjectsResultDto?> GetAsync(Guid id);
        public Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert);
        Task<ProjectsResultDto?> UpdateAsync(Guid id, ProjectDtoToUpdate toUpdate);
    }
}
