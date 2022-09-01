using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
{
    public partial class Department
    {
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentBlockNumber { get; set; }
    }
}
