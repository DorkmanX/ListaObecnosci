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
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        public TeacherDTO() 
        {
            this.Courses = new List<CourseDTO>();
            this.Groups = new List<GroupDTO>();
        }
        public virtual IList<CourseDTO> Courses { get; set; }
        public virtual IList<GroupDTO> Groups { get; set; }
    }
}
