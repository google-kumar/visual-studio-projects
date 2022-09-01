using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
{
    public partial class Bonu
    {
        public int? WorkerRefId { get; set; }
        public DateTime? BonusDate { get; set; }
        public int? BonusAmount { get; set; }

        public virtual Title? WorkerRef { get; set; }
    }
}
