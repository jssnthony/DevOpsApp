using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DevOpsAppData.Entities
{
    public class ProjectsTasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("task_index")]
        public int Index { get; set; }

        [Required]
        [Column("task_id")]
        [StringLength(36)]
        public Guid Id { get; set; }

        [ForeignKey("Project")]
        public int ProjectIndex { get; set; }

        [Required]
        [Column("task_title")]
        [StringLength(255)]
        public required string Title { get; set; }

        [Required]
        [Column("task_dexcription")]
        [StringLength(255)]
        public string? Description { get; set; }

        [Column("is_done")]
        public bool IsDone { get; set; } = false;

        public Projects Project { get; set; } = null!;
    }
}
