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
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int TeacherId { get; set; }
        public virtual TeacherDTO Teacher { get; set; }
        public virtual GroupDTO Group { get; set; }
        //zajecia -> classes
        public virtual IList<ClassesDTO> Classes { get; set; }

        public CourseDTO(string name, string description = "")
        {
            this.Name = name;
            this.Description = description;
            this.Classes = new List<ClassesDTO>();
        }
    }
}
