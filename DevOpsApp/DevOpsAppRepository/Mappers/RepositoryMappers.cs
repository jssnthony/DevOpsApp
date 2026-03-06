using Models.Projects;
using Models.ProjectsTasks;

namespace DevOpsAppRepository.Mappers
{
    public static class RepositoryMappers
    {
        public static ProjectBaseModel Parse(DevOpsAppData.Models.Project project)
        {
            return new ProjectBaseModel()
            {
                Id = project.ProjectId,
                Title = project.ProjectTitle,
                Description = project.ProjectDescription,
                Repository = project.ProjectRepository,
                IsActive = project.ProjectIsActive,
                IsArchive = project.ProjectIsArchive
            };
        }

        public static ViewTaskProjectBaseModel Parse(DevOpsAppData.Models.ViewTasksProject task)
        {
            return new ViewTaskProjectBaseModel()
            {
                ProgressStatus = (EnumProjectTasksStatus) task.TaskProgressStatus,
                ProjectDescription = task.ProjectDescription,
                ProjectId = task.ProjectId,
                ProjectRepository = task.ProjectRepository,
                ProjectTitle = task.ProjectTitle,
                TaskDescription = task.TaskDescription,
                TaskId = task.TaskId,
                TaskTitle = task.TaskTitle
            };
        }


    }
}
