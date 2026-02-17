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

        public async Task<bool> AlterProjectTaskStatusAsync(Guid TaskId)
        {
            return await _projectsTasksRepository.AlterProjectTaskStatusAsync(TaskId);
        }

        public async Task<IEnumerable<ViewProjectTaskDto>> GetAllProjectsTasksAsync(Guid ProjectId)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.GetAllProjectsTasksAsync(ProjectId));
        }

        public async Task<ViewProjectTaskDto?> GetProjectsTaskAsync(Guid TaskId)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.GetProjectsTaskAsync(TaskId));
        }

        public async Task<ViewProjectTaskDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert toInsert)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.InsertProjectTaskAsync(ProjectId, toInsert));
        }

        public async Task<ViewProjectTaskDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate toUpdate)
        {
            return ManagerMappers.Parse(
                await _projectsTasksRepository.UpdateProjectTaskAsync(TaskId, toUpdate));
        }
    }
}
