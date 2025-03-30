using AutoMapper;
using DevOpsAppData.Data;
using DevOpsAppData.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Projects;

namespace DevOpsAppData.ProjectsRepository
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDto?> ArchiveRecordAsync(Guid id)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (record == null)
                return null;
            record.IsArchive = true;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(record);
        }

        public async Task<ProjectDto?> DisableRecordAsync(Guid id)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (record == null)
                return null;
            record.IsActive = false;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(record);
        }

        public async Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            return await _context.Projects.Where(x=> !x.IsArchive && x.IsActive)
                .Select(x=> _mapper.Map<ProjectDto>(x)).ToListAsync();
        }

        public async Task<ProjectDto?> GetAsync(Guid id)
        {
            var record = await _context.Projects.Where(x => !x.IsArchive && x.IsActive)
                .FirstOrDefaultAsync(_ => _.Id == id);
            if (record == null) return null;
            return _mapper.Map<ProjectDto>(record);
        }

        public async Task<Guid?> InsertAsync(ProjectDtoToInsert toInsert)
        {
            var id = Guid.NewGuid();
            await _context.Projects.AddAsync(new Projects()
            {
                Description = toInsert.Description,
                Id = id,
                Title = toInsert.Title,
                Repository = toInsert.Repository,
                IsActive = true,
                IsArchive = false
            });

            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<ProjectDto?> UpsetAsync(ProjectDtoToUpdate toUpdate)
        {
            var record = await _context.Projects.FirstOrDefaultAsync(_ => _.Id == toUpdate.Id);
            if (record == null)
                return null;

            record.Title = toUpdate.Title;
            record.Repository = toUpdate.Repository;
            record.Description = toUpdate.Description;
            
            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectDto>(record);
        }
    }
}
