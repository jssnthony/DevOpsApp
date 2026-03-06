using Models.ProjectsTasks;

namespace DevOpsAppManager.Tasks
{
    public interface IProjectsTasksManager
    {
        public Task<ViewTaskProjectDto?> GetProjectsTaskAsync(Guid TaskId);

        public Task<IEnumerable<ViewTaskProjectDto>> GetAllProjectsTasksAsync(Guid ProjectId);

        public Task<ViewTaskProjectDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask);

        public Task<ViewTaskProjectDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask);
        
        public Task<EnumProjectTasksStatus> DeleteProjectTaskStatusAsync(Guid TaskId);
        
        Task<IEnumerable<ViewTaskProjectDto>> GetAllAsync();
    }
}
