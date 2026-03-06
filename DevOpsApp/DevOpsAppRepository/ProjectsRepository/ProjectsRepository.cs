using DevOpsAppData.Models;
using DevOpsAppRepository.Mappers;
using Microsoft.EntityFrameworkCore;
using Models.Projects;

namespace DevOpsAppRepository.ProjectsRepository
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly DevOpsAppContext _context;

        public ProjectsRepository(DevOpsAppContext context)
        {
            _context = context;
        }

        public async Task<ProjectBaseModel?> ArchiveRecordAsync(Guid id)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (record == null)
                return null;
            record.ProjectIsArchive = true;
            await _context.SaveChangesAsync();
            return RepositoryMappers.Parse(record);
        }

        public async Task<int> CountProjectsAsync()
        {
            var records = await _context.Projects.Where(x => !x.ProjectIsArchive && x.ProjectIsActive).CountAsync();
            return records;
        }

        public async Task<ProjectBaseModel?> DisableRecordAsync(Guid id)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (record == null)
                return null;
            record.ProjectIsActive = false;
            await _context.SaveChangesAsync();
            return RepositoryMappers.Parse(record);
        }

        public async Task<IEnumerable<ProjectBaseModel>> GetAllAsync()
        {
            return await _context.Projects.Where(x => !x.ProjectIsArchive && x.ProjectIsActive)
                .Select(x => RepositoryMappers.Parse(x)).ToListAsync();
        }

        public async Task<ProjectBaseModel?> GetAsync(Guid id)
        {
            var record = await _context.Projects.Where(x => !x.ProjectIsArchive && x.ProjectIsActive)
                .FirstOrDefaultAsync(_ => _.ProjectId == id);
            if (record == null) return null;
            return RepositoryMappers.Parse(record);
        }

        public async Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert)
        {
            var id = Guid.NewGuid();
            await _context.Projects.AddAsync(new Project()
            {
                ProjectTitle = toInsert.Title,
                ProjectId = id,
                ProjectDescription = toInsert.Description,
                ProjectRepository = toInsert.Repository,
                ProjectIsActive = true,
                ProjectIsArchive = false
            });

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<ProjectBaseModel?> UpsetAsync(ProjectDtoToUpdate toUpdate)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(_ => _.ProjectId == toUpdate.Id);
            if (record == null)
                return null;

            record.ProjectTitle = toUpdate.Title;
            record.ProjectRepository = toUpdate.Repository;
            record.ProjectDescription = toUpdate.Description;

            await _context.SaveChangesAsync();
            return RepositoryMappers.Parse(record);
        }
    }
}
