using AutoMapper;
using DevOpsAppRepository.ProjectsRepository;
using Models.Projects;

namespace DevOpsAppManager.Projects
{
    public class ProjectsManager : IProjectsManager
    {
        private readonly IProjectsRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsManager(
            IProjectsRepository projectRepository,
            IMapper mapper) { 
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<bool> ArchiveRecordAsync(Guid id)
        {
            return await _projectRepository.ArchiveRecordAsync(id) != null;
        }

        public async Task<bool> DisableRecordAsync(Guid id)
        {
            return await _projectRepository.DisableRecordAsync(id) != null;
        }

        public async Task<IEnumerable<ProjectsResultDto>> GetAsync()
        {
            var records = await _projectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProjectsResultDto>>(records);
        }

        public async Task<ProjectsResultDto?> GetAsync(Guid id)
        {
            var records = await _projectRepository.GetAsync(id);
            if(records == null)
                return null;
            return _mapper.Map<ProjectsResultDto>(records);
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

            return _mapper.Map<ProjectsResultDto>(record);
        }
    }
}
