using AutoMapper;
using DevOpsAppData.Entities;
using Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.ProjectsRepository
{
    public class ProjectsRepositoryProfile : Profile
    {
        public ProjectsRepositoryProfile() {
            CreateMap<Projects, ProjectDto>();
        }
    }
}
