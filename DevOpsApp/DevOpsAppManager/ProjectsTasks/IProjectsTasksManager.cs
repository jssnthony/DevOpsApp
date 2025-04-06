using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppManager.Tasks
{
    public interface IProjectsTasksManager
    {
        public Task<ProjectsTasksResultDto?> GetProjectsTaskAsync(Guid TaskId);

        public Task<IEnumerable<ProjectsTasksResultDto>> GetAllProjectsTasksAsync(Guid ProjectId);

        public Task<ProjectsTasksResultDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask);

        public Task<ProjectsTasksResultDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask);
        
        public Task<bool> AlterProjectTaskStatusAsync(Guid TaskId);
    }
}
