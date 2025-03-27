using DevOpsAppData.Entities;
using Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.ProjectsRepository
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<ProjectDto>> GetAll();
        Task Insert(ProjectDtoToInsert toInsert);
    }
}
