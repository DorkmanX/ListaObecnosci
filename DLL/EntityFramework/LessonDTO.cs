using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class LessonDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime LessonDate { get; set; }
        [Required]
        public bool IsDone { get; set; }
        public int CourseId { get; set; }
        public virtual CourseDTO Course { get; set; }
        public virtual IList<TimesheetDTO> Timesheets { get; set; }

        public LessonDTO(DateTime lessonDate, bool isDone) 
        {
            this.Timesheets = new List<TimesheetDTO>();
            this.LessonDate = lessonDate; this.IsDone = isDone;
        }
    }
}
