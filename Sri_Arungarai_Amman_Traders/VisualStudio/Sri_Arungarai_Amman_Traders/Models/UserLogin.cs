using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sri_Arungarai_Amman_Traders.Models
{
    public partial class UserLogin
    {

        [Display(Name = "User Name")]
        public string UserName { get; set; } = null!;

        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Range(5555555555, 9999999999)]
        public long? PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
