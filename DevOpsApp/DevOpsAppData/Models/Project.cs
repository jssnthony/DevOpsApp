namespace DevOpsAppData.Models;

public partial class Project
{
    public int ProjectIndex { get; set; }

    public Guid ProjectId { get; set; }

    public string ProjectTitle { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public string ProjectRepository { get; set; } = null!;

    public bool IsArchive { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<ProjectsTask> ProjectsTasks { get; set; } = new List<ProjectsTask>();
}
