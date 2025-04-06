using AutoMapper;
using DevOpsAppData.Data;
using DevOpsAppData.Entities;
using Microsoft.EntityFrameworkCore;
using Models.ProjectsTasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppRepository.ProjectsTasksRepository
{
    public class ProjectsTasksRespository : IProjectsTasksRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectsTasksRespository(ApplicationDbContext context,
            IMapper mapper) { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> AlterProjectTaskStatusAsync(Guid TaskId)
        {
            var task = await _context.ProjectsTasks.FirstOrDefaultAsync(x => x.Id == TaskId);
            if (task == null)
                return false;
            task.IsDone = !task.IsDone;
            await _context.SaveChangesAsync();
            return task.IsDone;
        }

        public async Task<IEnumerable<ProjectsTasksDto>> GetAllProjectsTasksAsync(Guid ProjectId)
        {
            return await _context.ProjectsTasks.Where(x => x.Project.Id == ProjectId)
                .Select(x => _mapper.Map<ProjectsTasksDto>(x))
                .ToListAsync();
        }

        public async Task<ProjectsTasksDto?> GetProjectsTaskAsync(Guid TaskId)
        {
            var record = await _context.ProjectsTasks.FirstOrDefaultAsync(x=> x.Id == TaskId);
            if (record == null) return null;
            return _mapper.Map<ProjectsTasksDto>(record);
        }

        public async Task<ProjectsTasksDto?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert toInsert)
        {
            var parentProjectRecord = await _context.Projects.FirstOrDefaultAsync(x=> x.Id == ProjectId);
            if (parentProjectRecord == null) return null;

            var newId = Guid.NewGuid();

            parentProjectRecord.Tasks.Add(new ProjectsTasks()
            {
                Description = toInsert.Description,
                Id = newId,
                IsDone = false,
                Title = toInsert.Title,
            });
            await _context.SaveChangesAsync();

            return await GetProjectsTaskAsync(newId);
        }

        public async Task<ProjectsTasksDto?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate toUpdate)
        {
            var record = await _context.ProjectsTasks.FirstOrDefaultAsync(x => x.Id == TaskId);
            if (record == null) return null;
            record.Title = toUpdate.Title;
            record.Description = toUpdate.Description;
            var result = _mapper.Map<ProjectsTasksDto>(record);
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
