using DevOpsAppData.ProjectsRepository;
using DevOpsAppManager.Projects;
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
        }
    }
}
