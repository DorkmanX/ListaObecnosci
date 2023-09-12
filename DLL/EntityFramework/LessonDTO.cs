using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class LessonDTO
    {
        [Key] public int Id { get; set; }
        [Required] public DateTime LessonDate { get; set; }
        [Required] public bool IsDone { get; set; }
        public int CourseId { get; set; }
        public virtual CourseDTO Course { get; set; }
        public virtual ICollection<TimesheetDTO> Timesheets { get; set; }

        public LessonDTO() 
        {
            Timesheets = new HashSet<TimesheetDTO>();
        }
    }
}
