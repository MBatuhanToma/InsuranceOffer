using System;
using System.Collections.Generic;

namespace Insurance.Models
{
    public partial class PersonInfo
    {
        public int Id { get; set; }
        public string IdentificationNumber { get; set; }
        public string LicensePlate { get; set; }
        public string LicenseSerialCode { get; set; }
        public string LicenseSerialNumber { get; set; }
    }
}
