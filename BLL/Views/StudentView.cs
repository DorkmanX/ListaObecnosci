using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL.Views
{
    public class StudentView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public GroupView Group { get; set; }
    }
}
