using Models.Projects;

namespace DevOpsAppRepository.ProjectsRepository
{
    public interface IProjectsRepository
    {
        Task<ProjectBaseModel?> ArchiveRecordAsync(Guid id);
        Task<ProjectBaseModel?> DisableRecordAsync(Guid id);
        Task<ProjectBaseModel?> GetAsync(Guid id);
        public Task<IEnumerable<ProjectBaseModel>> GetAllAsync();
        public Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert);
        Task<ProjectBaseModel?> UpsetAsync(ProjectDtoToUpdate toUpdate);
        Task<int> CountProjectsAsync();
    }
}
