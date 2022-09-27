using System;
using System.Collections.Generic;

namespace MVC_API_Client.Models
{
    public partial class Student
    {
        public int RollNo { get; set; }
        public string? StudentName { get; set; }
        public long? PhoneNum { get; set; }
        public string? Course { get; set; }
        public string? Tuitor { get; set; }
    }
}
