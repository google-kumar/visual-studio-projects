using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
{
    public partial class Car
    {
        public string? CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarType { get; set; }
        public string? OwnerId { get; set; }
    }
}
