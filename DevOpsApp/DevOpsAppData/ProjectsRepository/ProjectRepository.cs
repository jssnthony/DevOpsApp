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
                Description = x.Description,
                Id = x.Id,
                Repository = x.Repository
            }).ToListAsync();
        }
    }
}
