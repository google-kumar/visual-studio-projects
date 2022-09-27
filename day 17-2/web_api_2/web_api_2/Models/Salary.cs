using System;
using System.Collections.Generic;

namespace web_api_2.Models
{
    public partial class Salary
    {
        public int? EmployeeNo { get; set; }
        public string? TuitorName { get; set; }
        public int? Salary1 { get; set; }

        public virtual Tuitor? TuitorNameNavigation { get; set; }
    }
}
