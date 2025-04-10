using AutoMapper;
using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppManager.ProjectsTasks
{
    public class ProjectsTasksManagerProfile: Profile
    {
        public ProjectsTasksManagerProfile() {
            CreateMap<ProjectsTasksDto, ProjectsTasksResultDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId));
        }
    }
}
