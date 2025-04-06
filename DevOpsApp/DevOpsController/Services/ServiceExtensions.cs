using DevOpsAppData.ProjectsRepository;
using DevOpsAppManager.Projects;
using DevOpsAppManager.ProjectsTasks;
using DevOpsAppManager.Tasks;
using DevOpsManager.Projects;

namespace DevOpsController.Services
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(ProjectsManagerProfile));
            services.AddAutoMapper(typeof(ProjectsRepositoryProfile));

            services.AddScoped<IProjectsManager, ProjectsManager>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();

            services.AddScoped<IProjectsTasksManager, ProjectsTasksManager>();
        }
    }
}
