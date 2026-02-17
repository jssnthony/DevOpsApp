namespace Models.ProjectsTasks
{
    public class ProjectsTasksResultDto
    {
        public Guid TaskId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid ProjectId { get; set; }
    }
}
