using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class ClassesDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime ClassesDate { get; set; }
        [Required]
        public bool IsDone { get; set; }
        public virtual CourseDTO CourseDTO { get; set; }
        public virtual IList<TimesheetDTO> Timesheets { get; set; }

        public ClassesDTO() 
        {
            this.Timesheets = new List<TimesheetDTO>();
        }
    }
}
