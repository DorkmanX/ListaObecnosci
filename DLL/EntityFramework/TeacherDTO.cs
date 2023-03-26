using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public TeacherDTO() 
        {
            this.Courses = new HashSet<CourseDTO>();
            this.Groups= new HashSet<GroupDTO>();
        }
        public virtual ICollection<CourseDTO> Courses { get; set; }
        public virtual ICollection<GroupDTO> Groups { get; set; }
    }
}
