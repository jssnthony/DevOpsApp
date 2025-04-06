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
            CreateMap<ProjectsTasks, ProjectsTasksDto>();
        }
    }
}
