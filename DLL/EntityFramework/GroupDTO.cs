using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class GroupDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual TeacherDTO Teacher { get; set; }
        //public virtual ICollection<CourseDTO> Courses { get; set; }
        public virtual IList<UserDTO> Users { get; set; }

        public GroupDTO(string name, string description = "") 
        {
            Users = new List<UserDTO>();
            Name = name;
            Description = description;
        }
    }
}
