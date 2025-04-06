using Models.Projects;

namespace DevOpsAppRepository.ProjectsRepository
{
    public interface IProjectsRepository
    {
        Task<ProjectDto?> ArchiveRecordAsync(Guid id);
        Task<ProjectDto?> DisableRecordAsync(Guid id);
        Task<ProjectDto?> GetAsync(Guid id);
        public Task<IEnumerable<ProjectDto>> GetAllAsync();
        public Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert);
        Task<ProjectDto?> UpsetAsync(ProjectDtoToUpdate toUpdate);
    }
}
