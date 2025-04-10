using AutoMapper;
using Models.Projects;
using DevOpsAppData.Entities;

namespace DevOpsAppRepository.ProjectsRepository
{
    public class ProjectsRepositoryProfile : Profile
    {
        public ProjectsRepositoryProfile()
        {
            CreateMap<Projects, ProjectDto>();
        }
    }
}
