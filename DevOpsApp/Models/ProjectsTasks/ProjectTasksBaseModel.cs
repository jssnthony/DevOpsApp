using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ProjectsTasks
{
    public class ProjectTasksBaseModel
    {
        public Guid TaskId { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsDone { get; set; }
        public Guid ProjectId { get; set; }
    }
}
