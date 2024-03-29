﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.EntityFramework
{
    public class TimesheetDTO
    {
        [Key] public int Id { get; }
        [Required] public DateTime Date { get; set; }
        [Required] public bool IsPresence { get; set; }
        public int StudentId { get; set; }
        public virtual StudentDTO Student { get; set; }
    }
}
