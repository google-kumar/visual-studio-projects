using System;
using System.Collections.Generic;

namespace EntityFramework_example.Models
{
    public partial class DeliveryPartner
    {
        public string? PartnerId { get; set; }
        public string? PartnerName { get; set; }
        public long? PhoneNumber { get; set; }
        public int? Rating { get; set; }
    }
}
