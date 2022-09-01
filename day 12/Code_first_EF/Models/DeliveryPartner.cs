using System;
using System.Collections.Generic;

namespace Code_first_EF.Models
{
    public partial class DeliveryPartner
    {
        public string? PartnerId { get; set; }
        public string? PartnerName { get; set; }
        public long? PhoneNumber { get; set; }
        public int? Rating { get; set; }
    }
}
