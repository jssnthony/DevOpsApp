using AutoMapper;
using DevOpsAppData.Entities;
using Models.Projects;
using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppRepository.ProjectsTasksRepository
{
    public class ProjectsTasksRepositoryProfile : Profile
    {
        public ProjectsTasksRepositoryProfile()
        {
            CreateMap<ProjectsTasks, ProjectsTasksDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.Id))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Id));
            CreateMap<ViewProjectsTasks, ProjectsTasksDto>()
                .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TaskId));
        }
    }
}
