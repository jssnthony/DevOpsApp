using Models.ProjectsTasks;

namespace DevOpsAppRepository.ProjectsTasksRepository
{
    public interface IProjectsTasksRepository
    {
        public Task<ViewTaskProjectBaseModel?> GetProjectsTaskAsync(Guid TaskId);

        public Task<IEnumerable<ViewTaskProjectBaseModel>> GetAllProjectsTasksAsync(Guid ProjectId);

        public Task<ViewTaskProjectBaseModel?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask);

        public Task<ViewTaskProjectBaseModel?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask);

        public Task<EnumProjectTasksStatus> DeleteProjectTaskStatusAsync(Guid TaskId);
       
        Task<IEnumerable<ViewTaskProjectBaseModel>> GetAllAsync();
    }
}
