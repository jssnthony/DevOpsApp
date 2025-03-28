namespace Models.Projects
{
    public class ProjectDtoToInsert
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Repository { get; set; }
    }
}
