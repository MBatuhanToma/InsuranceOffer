using System;
using System.Collections.Generic;

namespace Insurance.Models
{
    public partial class OfferInsurance
    {
        public int OfferId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string OfferDescription { get; set; }
        public decimal? OfferAmount { get; set; }
        public string LicensePlate { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
