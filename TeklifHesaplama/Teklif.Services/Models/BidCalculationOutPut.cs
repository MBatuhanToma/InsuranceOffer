using System;
using System.Collections.Generic;
using System.Text;

namespace Teklif.Services.Models
{
    public class BidCalculationOutPut
    {
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string OfferDescription { get; set; }
        public double OfferAmount { get; set; }
        public string LicensePlate { get; set; }
        public string IdentificationNumber { get; set; }
    }
}
