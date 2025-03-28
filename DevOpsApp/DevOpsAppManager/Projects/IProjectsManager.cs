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
        Task<bool> ArchiveRecordAsync(Guid id);
        Task<bool> DisableRecordAsync(Guid id);
        public Task<IEnumerable<ProjectsResultDto>> GetAsync();
        Task<ProjectsResultDto?> GetAsync(Guid id);
        public Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert);
        Task<ProjectsResultDto?> UpdateAsync(Guid id, ProjectDtoToUpdate toUpdate);
    }
}
