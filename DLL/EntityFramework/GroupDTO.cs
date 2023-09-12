using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class GroupDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public virtual TeacherDTO? Teacher { get; set; }
        public virtual ICollection<CourseDTO> Courses { get; set; }
        public virtual ICollection<StudentDTO> Students { get; set; }
        public virtual ICollection<MarkDTO> Marks { get; set; }

        public GroupDTO() 
        {
            Students = new HashSet<StudentDTO>();
            Courses = new HashSet<CourseDTO>();
        }
    }
}
