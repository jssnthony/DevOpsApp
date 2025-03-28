using AutoMapper;
using DevOpsAppData.Entities;
using Models.Projects;

namespace DevOpsAppData.ProjectsRepository
{
    public class ProjectsRepositoryProfile : Profile
    {
        public ProjectsRepositoryProfile() {
            CreateMap<Projects, ProjectDto>();
        }
    }
}
