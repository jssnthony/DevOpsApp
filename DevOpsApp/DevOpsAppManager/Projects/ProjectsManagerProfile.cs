using AutoMapper;
using Models.Projects;

namespace DevOpsManager.Projects
{
    public class ProjectsManagerProfile : Profile
    {
        public ProjectsManagerProfile()
        {
            CreateMap<ProjectDto, ProjectsResultDto>();
        }
    }
}