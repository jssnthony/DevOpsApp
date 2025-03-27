using DevOpsAppData.Data;
using DevOpsAppData.Entities;
using Microsoft.EntityFrameworkCore;
using Models.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.ProjectsRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            return await _context.Projects.Select(x=> new ProjectDto { 
                Name = x.Name,
                Description = string.IsNullOrEmpty(x.Description)? "": x.Description,
                Id = x.Id,
                Repository = string.IsNullOrEmpty(x.Repository) ? "" : x.Repository
            }).ToListAsync();
        }

        public async Task<Guid> Insert(ProjectDtoToInsert toInsert)
        {
            var id = Guid.NewGuid();
            await _context.Projects.AddAsync(new Projects()
            {
                Description = toInsert.Description,
                Id = id,
                Name = toInsert.Name,
                Repository = toInsert.Repository
            });

            await _context.SaveChangesAsync();
            return id;
        }
    }
}
