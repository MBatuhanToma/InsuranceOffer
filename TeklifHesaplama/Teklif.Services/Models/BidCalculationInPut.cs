using System;
using System.Collections.Generic;
using System.Text;

namespace Teklif.Services.Models
{
    public class BidCalculationInPut
    {
        public string LicensePlate { get; set; }
        public string IdentificationNumber { get; set; }
        public string LicenseSerialCode { get; set; }
        public string LicenseSerialNumber { get; set; }
    }
}
