
using Models.ProjectsTasks;

namespace DevOpsAppRepository.ProjectsTasksRepository
{
    public interface IProjectsTasksRepository
    {
        public Task<ProjectsTasksDto?> GetProjectsTaskAsync(Guid TaskId);

        public Task<IEnumerable<ProjectsTasksDto>> GetAllProjectsTasksAsync(Guid ProjectId);

        public Task<ProjectsTasksDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask);

        public Task<ProjectsTasksDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask);

        public Task<bool> AlterProjectTaskStatusAsync(Guid TaskId);
    }
}
