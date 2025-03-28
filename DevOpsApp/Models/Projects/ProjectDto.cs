using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Projects
{
    public class ProjectDto
    {
        public int Index { get; set; }

        public Guid Id { get; set; }

        public required string Title { get; set; }

        public string? Description { get; set; }

        public string? Repository { get; set; }

        public bool IsArchive { get; set; } = false;

        public bool IsActive { get; set; } = false;
    }
}
