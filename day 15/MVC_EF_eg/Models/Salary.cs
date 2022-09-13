using System;
using System.Collections.Generic;

namespace MVC_EF_eg.Models
{
    public partial class Salary
    {
        public int? EmployeeNo { get; set; }
        public string? TuitorName { get; set; }
        public int? Salary1 { get; set; }

        public virtual Tuitor? TuitorNameNavigation { get; set; }
    }
}
