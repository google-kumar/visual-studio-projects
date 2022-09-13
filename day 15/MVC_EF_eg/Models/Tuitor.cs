using System;
using System.Collections.Generic;

namespace MVC_EF_eg.Models
{
    public partial class Tuitor
    {
        public Tuitor()
        {
            Students = new HashSet<Student>();
        }

        public int EmployeeNo { get; set; }
        public string TuitorName { get; set; } = null!;
        public long? PhoneNum { get; set; }
        public string? Course { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
