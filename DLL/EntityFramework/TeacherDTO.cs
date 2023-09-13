using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class TeacherDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Surname { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string Password { get; set; }
        public virtual ICollection<CourseDTO> Courses { get; set; }
        public virtual ICollection<GroupDTO> Groups { get; set; }
        public TeacherDTO()
        {
            Courses = new HashSet<CourseDTO>();
            Groups = new HashSet<GroupDTO>();
        }
    }
}
