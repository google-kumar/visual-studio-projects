using System;
using System.Collections.Generic;

namespace UserLogin___Sri_Arungarai_Amman_Traders.Models
{
    public partial class UserLogin
    {
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public long? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = null!;
    }
}
