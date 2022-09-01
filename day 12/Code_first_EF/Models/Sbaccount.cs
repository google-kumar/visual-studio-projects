using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
{
    public partial class Sbaccount
    {
        public long? AccountNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public decimal? CurrentBalance { get; set; }
    }
}
