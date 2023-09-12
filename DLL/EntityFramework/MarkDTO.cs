using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class MarkDTO
    {
        [Key] public int Id { get; }
        [Required] public DateTime Date { get; set; }
        [Required] public int Mark { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        public virtual StudentDTO Student { get; set; }
        public virtual CourseDTO Course { get; set; }
        public virtual GroupDTO Group { get; set; }
    }
}
