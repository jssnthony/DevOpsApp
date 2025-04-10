using DevOpsGateway.SDKs;
using Refit;

namespace DevOpsGateway.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Obtener la URI del API desde appsettings.json o variables de entorno
            string projectApiUri = configuration["ApiSettings:ProjectApi"]
                                   ?? Environment.GetEnvironmentVariable("PROJECT_API")
                                   ?? "https://default-url.com/";

            // Configurar HttpClient
            services.AddHttpClient("ProjectApi", client =>
            {
                client.BaseAddress = new Uri(projectApiUri);
            });

            // Configurar Refit (Opcional, si usas Refit)
            services.AddRefitClient<IProjectApi>()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri(projectApiUri));

            services.AddRefitClient<IProjectsTasksApi>()
                .ConfigureHttpClient(client => client.BaseAddress = new Uri(projectApiUri));
        }
    }
}
