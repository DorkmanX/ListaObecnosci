using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual TeacherDTO Teacher { get; set; }
        public virtual GroupDTO Group { get; set; }
        //zajecia -> classes
        public virtual ICollection<ClassesDTO> Classes { get; set; }
    }
}
