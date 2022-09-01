using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
{
    public partial class Title
    {
        public int WorkerRefId { get; set; }
        public string? WorkerTitle { get; set; }
        public DateTime? AffectedFrom { get; set; }
    }
}
