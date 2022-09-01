using System;
using System.Collections.Generic;

namespace EntityFramework_example.Models
{
    public partial class Car
    {
        public string? CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarType { get; set; }
        public string? OwnerId { get; set; }
    }
}
