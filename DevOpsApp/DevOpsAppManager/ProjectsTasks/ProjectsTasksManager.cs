using AutoMapper;
using DevOpsAppManager.Tasks;
using DevOpsAppRepository.ProjectsTasksRepository;
using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppManager.ProjectsTasks
{
    public class ProjectsTasksManager : IProjectsTasksManager
    {
        private readonly IProjectsTasksRepository _projectsTasksRepository;
        private readonly IMapper _mapper;

        public ProjectsTasksManager(IProjectsTasksRepository projectsTasksRepository,
            IMapper mapper) {
            _projectsTasksRepository = projectsTasksRepository;
            _mapper = mapper;

        }

        public async Task<bool> AlterProjectTaskStatusAsync(Guid TaskId)
        {
            return await _projectsTasksRepository.AlterProjectTaskStatusAsync(TaskId);
        }

        public async Task<IEnumerable<ProjectsTasksResultDto>> GetAllProjectsTasksAsync(Guid ProjectId)
        {
            return _mapper.Map<IEnumerable<ProjectsTasksResultDto>>(
                await _projectsTasksRepository.GetAllProjectsTasksAsync(ProjectId));
        }

        public async Task<ProjectsTasksResultDto?> GetProjectsTaskAsync(Guid TaskId)
        {
            return _mapper.Map<ProjectsTasksResultDto>(
                await _projectsTasksRepository.GetProjectsTaskAsync(TaskId));
        }

        public async Task<ProjectsTasksResultDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert toInsert)
        {
            return _mapper.Map<ProjectsTasksResultDto>(
                await _projectsTasksRepository.InsertProjectTaskAsync(ProjectId, toInsert));
        }

        public async Task<ProjectsTasksResultDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate toUpdate)
        {
            return _mapper.Map<ProjectsTasksResultDto>(
                await _projectsTasksRepository.UpdateProjectTaskAsync(TaskId, toUpdate));
        }
    }
}
