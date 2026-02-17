using Models.ProjectsTasks;

namespace DevOpsAppManager.Tasks
{
    public interface IProjectsTasksManager
    {
        public Task<ViewProjectTaskDto?> GetProjectsTaskAsync(Guid TaskId);

        public Task<IEnumerable<ViewProjectTaskDto>> GetAllProjectsTasksAsync(Guid ProjectId);

        public Task<ViewProjectTaskDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask);

        public Task<ViewProjectTaskDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask);
        
        public Task<bool> AlterProjectTaskStatusAsync(Guid TaskId);
    }
}
