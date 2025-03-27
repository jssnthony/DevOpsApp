using Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppManager.Projects
{
    public interface IProjectsManager
    {
        public Task<IEnumerable<ProjectsResultDto>> GetAsync();

        public Task InsertAsync(ProjectDtoToInsert toInsert);
    }
}
