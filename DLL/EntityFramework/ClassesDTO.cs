using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class ClassesDTO
    {
        public int Id { get; set; }
        public DateTime ClassesDate { get; set; }
        public bool IsDone { get; set; }
        public virtual CourseDTO CourseDTO { get; set; }
        public virtual ICollection<TimesheetDTO> Timesheets { get; set; }
    }
}
