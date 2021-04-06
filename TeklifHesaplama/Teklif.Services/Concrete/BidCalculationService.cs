using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teklif.Services.Abstract;
using Teklif.Services.Models;

namespace Teklif.Services.Concrete
{
    public class BidCalculationService : IBidCalculation
    {
        public async Task<BidCalculationOutPut> BidCalculation(BidCalculationInPut data, string company)
        {
            switch (company)
            {
                case "A":
                    return new BidCalculationOutPut()
                    {
                        CompanyLogo = "AAA",
                        CompanyName = "ACompany",
                        OfferAmount = new Random().Next(1, 100),
                        OfferDescription = "descA",
                        LicensePlate = data.LicensePlate,
                        IdentificationNumber = data.IdentificationNumber
                    };

                    break;

                case "B":
                    return new BidCalculationOutPut()
                    {
                        CompanyLogo = "BBB",
                        CompanyName = "BCompany",
                        OfferAmount = new Random().Next(100, 1000),
                        OfferDescription = "descB",
                        LicensePlate = data.LicensePlate,
                        IdentificationNumber = data.IdentificationNumber
                    };
                    break;

                case "C":
                    return new BidCalculationOutPut()
                    {
                        CompanyLogo = "CCC",
                        CompanyName = "CCompany",
                        OfferAmount = new Random().Next(1000, 10000),
                        OfferDescription = "descC",
                        LicensePlate = data.LicensePlate,
                        IdentificationNumber = data.IdentificationNumber
                    };
                    break;

                default:
                    return null;
            }


        }
    }
}
