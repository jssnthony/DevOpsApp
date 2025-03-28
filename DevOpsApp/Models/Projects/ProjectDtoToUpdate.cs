namespace Models.Projects
{
    public class ProjectDtoToUpdate
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Repository { get; set; }
    }
}
