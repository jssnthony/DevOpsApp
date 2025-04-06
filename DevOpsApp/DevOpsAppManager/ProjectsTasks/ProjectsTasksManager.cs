using DevOpsAppManager.Tasks;
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
        public Task<bool> AlterProjectTaskStatusAsync(Guid TaskId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectsTasksResultDto>> GetAllProjectsTasksAsync(Guid ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectsTasksResultDto?> GetProjectsTaskAsync(Guid TaskId)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectsTasksResultDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert ProjectTask)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectsTasksResultDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate ProjectTask)
        {
            throw new NotImplementedException();
        }
    }
}
