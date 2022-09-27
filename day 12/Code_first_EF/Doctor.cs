using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Code_first_EF
{
    internal class Doctor
    {
        [Key]
        [Display(Name ="Doctor ID")]
        public int DocID { get; set; }
        public string DocName { get; set; }
        public string Specialization { get; set; }
        public float yrsofExp { get; set; }

        public int SeniorID { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
