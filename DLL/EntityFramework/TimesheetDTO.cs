using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class TimesheetDTO
    {
        public int Id { get; }
        public DateTime Date { get; }
        public bool IsPresence { get; }
        public float Mark { get; }
        public virtual StudentDTO User { get; }

        public TimesheetDTO(DateTime date,bool isPresence,float mark) 
        {
            Date = date;
            IsPresence = isPresence;
            Mark = mark;
        }
    }
}
