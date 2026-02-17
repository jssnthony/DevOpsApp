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
                IsActive = project.IsActive,
                IsArchive = project.IsArchive
            };
        }

        public static ViewProjectTaskBaseModel Parse(DevOpsAppData.Models.ViewProjectsTask task)
        {
            return new ViewProjectTaskBaseModel()
            {
                IsDone = task.IsDone,
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
