using System;
using System.Collections.Generic;

namespace EntityFramework_example.Models
{
    public partial class Worker
    {
        public int WorkerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Salary { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Dapartment { get; set; }
    }
}
