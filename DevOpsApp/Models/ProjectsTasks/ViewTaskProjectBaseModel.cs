using Models.Projects;

namespace Models.ProjectsTasks
{
    public class ViewTaskProjectBaseModel
    {
        public Guid TaskId { get; set; }

        public string TaskTitle { get; set; } = null!;

        public string TaskDescription { get; set; } = null!;

        public EnumProjectTasksStatus ProgressStatus { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectTitle { get; set; } = null!;

        public string ProjectDescription { get; set; } = null!;

        public string ProjectRepository { get; set; } = null!;
    }
}
