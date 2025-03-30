namespace Models.Projects
{
    public class ProjectsResultDto
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Repository { get; set; }
    }
}
