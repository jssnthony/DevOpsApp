using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevOpsAppData.Entities
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PROJECT_INDEX")]
        public int Index { get; set; } 

        [Required]
        [Column("PROJECT_ID")]
        [StringLength(36)]
        public Guid Id { get; set; } 

        [Required]
        [Column("PROJECT_TITLE")]
        [StringLength(255)]
        public required string Title { get; set; } 

        [Column("PROJECT_DESCRIPTION", TypeName = "TEXT")]
        public string? Description { get; set; } 

        [Column("PROJECT_REPOSITORY")]
        [StringLength(255)]
        public string? Repository { get; set; } 

        [Column("IS_ARCHIVE")]
        public bool IsArchive { get; set; } = false; 

        [Column("IS_ACTIVE")]
        public bool IsActive { get; set; } = false; 
    }
}
