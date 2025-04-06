using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOpsAppData.Entities
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("project_index")]
        public int Index { get; set; } 

        [Required]
        [Column("project_id")]
        [StringLength(36)]
        public Guid Id { get; set; } 

        [Required]
        [Column("project_title")]
        [StringLength(255)]
        public required string Title { get; set; } 

        [Column("project_description", TypeName = "text")]
        public string? Description { get; set; } 

        [Column("project_repository")]
        [StringLength(255)]
        public string? Repository { get; set; } 

        [Column("is_archive")]
        public bool IsArchive { get; set; } = false; 

        [Column("is_active")]
        public bool IsActive { get; set; } = false;

        public ICollection<ProjectsTasks> Tasks { get; set; } = new List<ProjectsTasks>();
    }
}
