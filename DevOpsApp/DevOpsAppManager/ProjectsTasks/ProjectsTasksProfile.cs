using AutoMapper;
using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppManager.ProjectsTasks
{
    public class ProjectsTasksProfile: Profile
    {
        public ProjectsTasksProfile() {
            CreateMap<ProjectsTasksDto, ProjectsTasksResultDto>();
        }
    }
}
