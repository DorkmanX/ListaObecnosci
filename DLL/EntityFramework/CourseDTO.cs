using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class CourseDTO
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public int? GroupId { get; set; }
        public virtual TeacherDTO? Teacher { get; set; }
        public virtual GroupDTO? Group { get; set; }
        public virtual ICollection<LessonDTO> Lessons { get; set; }
        public virtual ICollection<MarkDTO> Marks { get; set; }

        public CourseDTO()
        {
            Lessons = new HashSet<LessonDTO>();
            Marks = new HashSet<MarkDTO>();
        }
    }
}
