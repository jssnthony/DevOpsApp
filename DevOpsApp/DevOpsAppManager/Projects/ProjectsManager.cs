using DevOpsAppManager.Mappers;
using DevOpsAppRepository.ProjectsRepository;
using Models.Projects;

namespace DevOpsAppManager.Projects
{
    public class ProjectsManager : IProjectsManager
    {
        private readonly IProjectsRepository _projectRepository;

        public ProjectsManager(
            IProjectsRepository projectRepository) { 
            _projectRepository = projectRepository;
        }

        public async Task<bool> ArchiveRecordAsync(Guid id)
        {
            return await _projectRepository.ArchiveRecordAsync(id) != null;
        }

        public async Task<ProjectStats> GetStatsProjectsAsync()
        {
            var totalItems = await _projectRepository.CountProjectsAsync();
            var stats = new ProjectStats
            {
                TotalItems = totalItems
            };
            return stats;
        }

        public async Task<bool> DisableRecordAsync(Guid id)
        {
            return await _projectRepository.DisableRecordAsync(id) != null;
        }

        public async Task<IEnumerable<ProjectsResultDto>> GetAsync()
        {
            var records = await _projectRepository.GetAllAsync();
            return ManagerMappers.Parse(records);
        }

        public async Task<ProjectsResultDto?> GetAsync(Guid id)
        {
            var records = await _projectRepository.GetAsync(id);
            if(records == null)
                return null;
            return ManagerMappers.Parse(records);
        }

        public async Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert)
        {
            return await _projectRepository.InsertAsync(toInsert);
        }

        public async Task<ProjectsResultDto?> UpdateAsync(Guid id, ProjectDtoToUpdate toUpdate)
        {
            if(id != toUpdate.Id)
                return null;

            var record = await _projectRepository.UpsetAsync(toUpdate);
            if (record == null)
                return null;

            return ManagerMappers.Parse(record);
        }
    }
}
