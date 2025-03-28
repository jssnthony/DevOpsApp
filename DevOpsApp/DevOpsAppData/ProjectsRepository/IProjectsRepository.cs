using DevOpsAppData.Entities;
using Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.ProjectsRepository
{
    public interface IProjectsRepository
    {
        Task<ProjectDto?> ArchiveRecordAsync(Guid id);
        Task<ProjectDto?> DisableRecordAsync(Guid id);
        Task<ProjectDto?> GetAsync(Guid id);
        public Task<IEnumerable<ProjectDto>> GetAllAsync();
        public Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert);
        Task<ProjectDto?> UpsetAsync(ProjectDtoToUpdate toUpdate);
    }
}
