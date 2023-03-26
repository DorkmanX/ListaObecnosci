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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public virtual IList<TimesheetDTO> Timesheets { get; set; }
        public virtual IList<GroupDTO> Groups { get; set; }

        public StudentDTO(string name, string surname)
        {
            this.Groups = new List<GroupDTO>();
            this.Timesheets = new List<TimesheetDTO>();
            this.Name = name; this.Surname = surname;
        }
    }
}
