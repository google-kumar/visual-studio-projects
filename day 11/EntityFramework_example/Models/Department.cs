using System;
using System.Collections.Generic;

namespace EntityFramework_example.Models
{
    public partial class Department
    {
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public int? DepartmentBlockNumber { get; set; }
    }
}
