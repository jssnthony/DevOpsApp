using DevOpsAppData.Models;
using DevOpsAppRepository.Mappers;
using Microsoft.EntityFrameworkCore;
using Models.ProjectsTasks;

namespace DevOpsAppRepository.ProjectsTasksRepository
{
    public class ProjectsTasksRespository : IProjectsTasksRepository
    {
        private readonly DevOpsAppContext _context;
        public ProjectsTasksRespository(DevOpsAppContext context) { 
            _context = context;
        }

        public async Task<EnumProjectTasksStatus> DeleteProjectTaskStatusAsync(Guid TaskId)
        {
            var task = await _context.ProjectsTasks.FirstOrDefaultAsync(x => x.TaskId == TaskId);
            task.TaskProgressStatus = (int)EnumProjectTasksStatus.IsDeleted;
            await _context.SaveChangesAsync();
            return (EnumProjectTasksStatus)task.TaskProgressStatus;
        }

        public async Task<IEnumerable<ViewTaskProjectBaseModel>> GetAllAsync()
        {
            return await _context.ViewTasksProjects
               .Select(x => RepositoryMappers.Parse(x))
               .ToListAsync();
        }

        public async Task<IEnumerable<ViewTaskProjectBaseModel>> GetAllProjectsTasksAsync(Guid ProjectId)
        {
            return await _context.ViewTasksProjects.Where(x => x.ProjectId == ProjectId)
                .Select(x => RepositoryMappers.Parse(x))
                .ToListAsync();
        }

        public async Task<ViewTaskProjectBaseModel?> GetProjectsTaskAsync(Guid TaskId)
        {
            var record = await _context.ViewTasksProjects
                .FirstOrDefaultAsync(x=> x.TaskId == TaskId);
            if (record == null) return null;
            var result = RepositoryMappers.Parse(record);
            return result;
        }

        public async Task<ViewTaskProjectBaseModel?> InsertProjectTaskAsync(Guid ProjectId, ProjectTaskToInsert toInsert)
        {
            var parentProjectRecord = await _context.Projects.FirstOrDefaultAsync(x=> x.ProjectId == ProjectId);
            if (parentProjectRecord == null) return null;

            var newId = Guid.NewGuid();

            parentProjectRecord.ProjectsTasks.Add(new ProjectsTask()
            {
                TaskDescription = toInsert.Description,
                TaskId = newId,
                TaskProgressStatus = (int) EnumProjectTasksStatus.Idea,
                TaskTitle = toInsert.Title
            });
            await _context.SaveChangesAsync();

            return await GetProjectsTaskAsync(newId);
        }

        public async Task<ViewTaskProjectBaseModel?> UpdateProjectTaskAsync(Guid TaskId, ProjectTaskToUpdate toUpdate)
        {
            var record = await _context.ProjectsTasks
                .Include(x => x.ProjectIndex)
                .FirstOrDefaultAsync(x => x.TaskId == TaskId);
            if (record == null) return null;

            record.TaskTitle = toUpdate.Title;
            record.TaskDescription = toUpdate.Description;
            
            await _context.SaveChangesAsync();
            return await GetProjectsTaskAsync(TaskId);
        }
    }
}
