﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_first_EF
{
    class Patient
    {
        [Key]

        public int PatientID { get; set; }
        public string PatientName { get; set; }

        //public int DoctorID {get;set;}
        public Doctor doctor { get; set; }
    }
}
