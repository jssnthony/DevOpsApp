using Models.ProjectsTasks;

namespace DevOpsAppRepository.ProjectsTasksRepository
{
    public interface IProjectsTasksRepository
    {
        public Task<ViewProjectTaskBaseModel?> GetProjectsTaskAsync(Guid TaskId);

        public Task<IEnumerable<ViewProjectTaskBaseModel>> GetAllProjectsTasksAsync(Guid ProjectId);

        public Task<ViewProjectTaskBaseModel?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask);

        public Task<ViewProjectTaskBaseModel?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask);

        public Task<bool> AlterProjectTaskStatusAsync(Guid TaskId);
    }
}
