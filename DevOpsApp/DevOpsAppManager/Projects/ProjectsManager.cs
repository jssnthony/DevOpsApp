using AutoMapper;
using DevOpsAppData.ProjectsRepository;
using Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppManager.Projects
{
    public class ProjectsManager : IProjectsManager
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsManager(
            IProjectRepository projectRepository,
            IMapper mapper) { 
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectsResultDto>> GetAsync()
        {
            var records = await _projectRepository.GetAll();
            return _mapper.Map<IEnumerable<ProjectsResultDto>>(records);
        }

        public async Task<Guid> InsertAsync(ProjectDtoToInsert toInsert)
        {
            return await _projectRepository.Insert(toInsert);
        }
    }
}
