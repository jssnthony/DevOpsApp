using DevOpsAppManager.Projects;
using DevOpsAppManager.ProjectsTasks;
using DevOpsAppManager.Tasks;
using DevOpsAppRepository.ProjectsRepository;
using DevOpsAppRepository.ProjectsTasksRepository;

namespace DevOpsController.Services
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectsManager, ProjectsManager>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();

            services.AddScoped<IProjectsTasksManager, ProjectsTasksManager>();
            services.AddScoped<IProjectsTasksRepository, ProjectsTasksRespository>();
            
        }
    }
}
