using DevOpsAppManager.Inventory;
using DevOpsAppManager.Projects;
using DevOpsAppManager.ProjectsTasks;
using DevOpsAppManager.Tasks;
using DevOpsAppRepository.InventoryRepository;
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

            services.AddScoped<IInventoryManager, InventoryManager>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();

        }
    }
}
