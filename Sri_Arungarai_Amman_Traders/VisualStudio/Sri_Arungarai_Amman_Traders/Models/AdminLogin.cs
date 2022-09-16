using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class AdminLogin
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}