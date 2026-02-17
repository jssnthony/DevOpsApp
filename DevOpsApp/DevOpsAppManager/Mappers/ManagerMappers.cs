using Models.Projects;
using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevOpsAppManager.Mappers
{
    public static class ManagerMappers
    {
        public static ProjectsResultDto Parse(ProjectBaseModel model)
        {
            return new ProjectsResultDto()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Repository = model.Repository
            };
        }

        public static IEnumerable<ProjectsResultDto> Parse(IEnumerable<ProjectBaseModel> models)
        {
            var result = new List<ProjectsResultDto>();
            foreach (var model in models)
            {
                result.Add(Parse(model));
            }
            return result;
        }

        public static ViewProjectTaskDto Parse(ViewProjectTaskBaseModel model)
        {
            return new ViewProjectTaskDto()
            {
                IsDone = model.IsDone,
                ProjectDescription = model.ProjectDescription,
                ProjectId = model.ProjectId,
                ProjectRepository = model.ProjectRepository,
                ProjectTitle = model.ProjectTitle,
                TaskDescription = model.TaskDescription,
                TaskId = model.TaskId,
                TaskTitle = model.TaskTitle
            };
        }
         public static IEnumerable<ViewProjectTaskDto> Parse(IEnumerable<ViewProjectTaskBaseModel> models)
        {
            var result = new List<ViewProjectTaskDto>();
            foreach (var model in models)
            {
                result.Add(Parse(model));
            }
            return result;
         }
    }
}
