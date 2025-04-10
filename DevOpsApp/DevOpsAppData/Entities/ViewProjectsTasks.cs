using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.Entities
{
    [Table("view_projects_tasks")]  
    public class ViewProjectsTasks
    {
        [Column("task_id")]
        public Guid TaskId { get; set; } 

        [Column("project_id")]
        public Guid ProjectId { get; set; }  

        [Column("task_title")]
        public string Title { get; set; } 

        [Column("task_description")]
        public string? Description { get; set; }  

        [Column("is_done")]
        public bool IsDone { get; set; }
    }
}
