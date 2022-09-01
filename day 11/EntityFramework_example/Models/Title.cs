using System;
using System.Collections.Generic;

namespace EntityFramework_example.Models
{
    public partial class Title
    {
        public int WorkerRefId { get; set; }
        public string? WorkerTitle { get; set; }
        public DateTime? AffectedFrom { get; set; }
    }
}
