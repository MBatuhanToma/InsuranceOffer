using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Models
{
    public class BidCalculationInPut
    {
        public string LicensePlate { get; set; }
        public string IdentificationNumber { get; set; }
        public string LicenseSerialCode { get; set; }
        public string LicenseSerialNumber { get; set; }
    }
}
