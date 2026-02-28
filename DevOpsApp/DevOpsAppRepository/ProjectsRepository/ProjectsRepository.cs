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
            record.IsArchive = true;
            await _context.SaveChangesAsync();
            return RepositoryMappers.Parse(record);
        }

        public async Task<int> CountProjectsAsync()
        {
            var records = await _context.Projects.Where(x => !x.IsArchive && x.IsActive).CountAsync();
            return records;
        }

        public async Task<ProjectBaseModel?> DisableRecordAsync(Guid id)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
            if (record == null)
                return null;
            record.IsActive = false;
            await _context.SaveChangesAsync();
            return RepositoryMappers.Parse(record);
        }

        public async Task<IEnumerable<ProjectBaseModel>> GetAllAsync()
        {
            return await _context.Projects.Where(x => !x.IsArchive && x.IsActive)
                .Select(x => RepositoryMappers.Parse(x)).ToListAsync();
        }

        public async Task<ProjectBaseModel?> GetAsync(Guid id)
        {
            var record = await _context.Projects.Where(x => !x.IsArchive && x.IsActive)
                .FirstOrDefaultAsync(_ => _.ProjectId == id);
            if (record == null) return null;
            return RepositoryMappers.Parse(record);
        }

        public async Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert)
        {
            var id = Guid.NewGuid();
            await _context.Projects.AddAsync(new Project()
            {
                ProjectTitle = toInsert.Description,
                ProjectId = id,
                ProjectDescription = toInsert.Title,
                ProjectRepository = toInsert.Repository,
                IsActive = true,
                IsArchive = false
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
