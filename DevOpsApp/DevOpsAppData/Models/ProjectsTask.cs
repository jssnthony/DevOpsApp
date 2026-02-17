namespace DevOpsAppData.Models;

public partial class ProjectsTask
{
    public int TaskIndex { get; set; }

    public Guid TaskId { get; set; }

    public int ProjectIndex { get; set; }

    public string TaskTitle { get; set; } = null!;

    public string TaskDescription { get; set; } = null!;

    public bool IsDone { get; set; }

    public virtual Project ProjectIndexNavigation { get; set; } = null!;
}
