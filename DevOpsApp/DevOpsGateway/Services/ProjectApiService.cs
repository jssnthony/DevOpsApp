namespace DevOpsGateway.Services
{
    public class ProjectApiService
    {
        private readonly HttpClient _httpClient;

        public ProjectApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetProjects()
        {
            var response = await _httpClient.GetAsync("api/endpoint"); // Cambia por tu endpoint real
            response.EnsureSuccessStatusCode(); // Lanza excepción si la respuesta no es exitosa

            return await response.Content.ReadAsStringAsync();
        }
    }
}
