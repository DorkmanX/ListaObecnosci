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
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public virtual TeacherDTO Teacher { get; set; }
        public virtual IList<CourseDTO> Courses { get; set; }
        public virtual IList<StudentDTO> Students { get; set; }

        public GroupDTO(string name, string description = "") 
        {
            this.Students = new List<StudentDTO>();
            this.Courses = new List<CourseDTO>();
            this.Name = name;
            this.Description = description;
        }
    }
}
