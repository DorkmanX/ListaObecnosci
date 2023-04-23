using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class CourseDTO
    {
        public int Id { get; set; }
        [Required] public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public int? GroupId { get; set; }
        public virtual TeacherDTO Teacher { get; set; }
        public virtual GroupDTO Group { get; set; }
        public virtual IList<LessonDTO> Lessons { get; set; }

        public CourseDTO(string name, string description = "")
        {
            this.Name = name;
            this.Description = description;
            this.Lessons = new List<LessonDTO>();
        }
    }
}
