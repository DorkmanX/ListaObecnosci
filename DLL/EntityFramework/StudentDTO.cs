using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class StudentDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        public virtual ICollection<TimesheetDTO> Timesheets { get; set; }
        public virtual ICollection<GroupDTO> Groups { get; set; }
        public virtual ICollection<MarkDTO> Marks { get; set; }
        public StudentDTO() 
        { 
            Timesheets = new HashSet<TimesheetDTO>();
            Groups = new HashSet<GroupDTO>();
            Marks = new HashSet<MarkDTO>();
        }
    }
}
