using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
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
