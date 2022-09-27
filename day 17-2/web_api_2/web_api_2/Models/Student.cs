using System;
using System.Collections.Generic;

namespace web_api_2.Models
{
    public partial class Student
    {
        public int RollNo { get; set; }
        public string? StudentName { get; set; }
        public long? PhoneNum { get; set; }
        public string? Course { get; set; }
        public string? Tuitor { get; set; }

        public virtual Tuitor? TuitorNavigation { get; set; }
    }
}
