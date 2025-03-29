namespace Models.Projects
{
    public class ProjectDtoToInsert
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? Repository { get; set; }
    }
}
