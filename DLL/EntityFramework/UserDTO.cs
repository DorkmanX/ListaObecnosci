using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        //public virtual ICollection<TimesheetDTO> Timesheets { get; set; }
        public virtual IList<GroupDTO> Groups { get; set; }

        public UserDTO(string name, string surname)
        {
            Groups = new List<GroupDTO>();
            Name = name; Surname = surname;
        }
    }
}
