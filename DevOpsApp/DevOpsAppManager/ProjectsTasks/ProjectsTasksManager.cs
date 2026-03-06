using DevOpsAppManager.Mappers;
using DevOpsAppManager.Tasks;
using DevOpsAppRepository.ProjectsTasksRepository;
using Models.ProjectsTasks;

namespace DevOpsAppManager.ProjectsTasks
{
    public class ProjectsTasksManager : IProjectsTasksManager
    {
        private readonly IProjectsTasksRepository _projectsTasksRepository;

        public ProjectsTasksManager(IProjectsTasksRepository projectsTasksRepository) {
            _projectsTasksRepository = projectsTasksRepository;
        }

        public async Task<EnumProjectTasksStatus> DeleteProjectTaskStatusAsync(Guid TaskId)
        {
            return await _projectsTasksRepository.DeleteProjectTaskStatusAsync(TaskId);
        }

        public async Task<IEnumerable<ViewTaskProjectDto>> GetAllAsync()
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.GetAllAsync());
        }

        public async Task<IEnumerable<ViewTaskProjectDto>> GetAllProjectsTasksAsync(Guid ProjectId)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.GetAllProjectsTasksAsync(ProjectId));
        }

        public async Task<ViewTaskProjectDto?> GetProjectsTaskAsync(Guid TaskId)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.GetProjectsTaskAsync(TaskId));
        }

        public async Task<ViewTaskProjectDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert toInsert)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.InsertProjectTaskAsync(ProjectId, toInsert));
        }

        public async Task<ViewTaskProjectDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate toUpdate)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.UpdateProjectTaskAsync(TaskId, toUpdate));
        }
    }
}
