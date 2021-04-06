using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Insurance.Core.Extentions;
using Insurance.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Controllers
{

    public class PersonController : Controller
    {
        InsuranceContext db = new InsuranceContext();

        public IActionResult Index()
        {
            return View(db.PersonInfo.ToList());
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetOffersAccordingToTckn()
        {
            //var getTckn = db.OfferInsurance.Where(p => p.IdentificationNumber == p1.IdentificationNumber).ToList();

            return View("GetOffersAccordingToTckn");
        }

        [HttpPost]
        public IActionResult GetOffersAccordingToTckn(PersonInfo p1)
        {
            var getTckn = db.OfferInsurance.Where(p => p.IdentificationNumber == p1.IdentificationNumber).ToList();

            return View(getTckn);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePerson(PersonInfo p1)
        {
            if (p1.IdentificationNumber != null && p1.LicensePlate != null &&
                p1.LicenseSerialCode == null && p1.LicenseSerialNumber == null)
            {
                var persons = db.PersonInfo.Where(m => m.IdentificationNumber == p1.IdentificationNumber &&
                   m.LicensePlate == p1.LicensePlate).ToList();

                if (persons.Count > 0)
                {
                    var result = new OkObjectResult(new { message = "200", name = persons });
                    return result;
                }
                else
                {
                    var result = new OkObjectResult(new { message = "201", name = persons });
                    return result;
                }
            }
            else
            {
                db.Add(p1);
                db.SaveChanges();

                var getSerializeAndSetting = await GetOffers(p1);

                foreach (var item in getSerializeAndSetting)
                {
                    db.Add(item);
                }


                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public async Task<List<OfferInsurance>> GetOffers(PersonInfo personInfo)
        {
            var list = new List<OfferInsurance>();

            BidCalculationInPut b = new BidCalculationInPut() { LicensePlate = personInfo.LicensePlate, IdentificationNumber = personInfo.IdentificationNumber };

            var companyA = JsonExtention.GetJsonGenericType<BidCalculationOutPut>(await HttpExtention.SendRequest("https://localhost:44343/api/Company/GetCompanyA", b));
            var companyB = JsonExtention.GetJsonGenericType<BidCalculationOutPut>(await HttpExtention.SendRequest("https://localhost:44343/api/Company/GetCompanyB", b));
            var companyC = JsonExtention.GetJsonGenericType<BidCalculationOutPut>(await HttpExtention.SendRequest("https://localhost:44343/api/Company/GetCompanyC", b));
           
            OfferInsurance ACompanyOfferInsurance = new OfferInsurance()
            {
                CompanyLogo = companyA.companyLogo,
                CompanyName = companyA.companyName,
                LicensePlate = companyA.licensePlate,
                OfferAmount = Convert.ToDecimal(companyA.offerAmount),
                OfferDescription = companyA.offerDescription,
                IdentificationNumber = companyA.identificationNumber
            };

            list.Add(ACompanyOfferInsurance);

            OfferInsurance BCompanyOfferInsurance = new OfferInsurance()
            {
                CompanyLogo = companyB.companyLogo,
                CompanyName = companyB.companyName,
                LicensePlate = companyB.licensePlate,
                OfferAmount = Convert.ToDecimal(companyB.offerAmount),
                OfferDescription = companyB.offerDescription,
                IdentificationNumber = companyB.identificationNumber
            };
            list.Add(BCompanyOfferInsurance);

            OfferInsurance CCompanyOfferInsurance = new OfferInsurance()
            {
                CompanyLogo = companyC.companyLogo,
                CompanyName = companyC.companyName,
                LicensePlate = companyC.licensePlate,
                OfferAmount = Convert.ToDecimal(companyC.offerAmount),
                OfferDescription = companyC.offerDescription,
                IdentificationNumber = companyC.identificationNumber
            };

            list.Add(CCompanyOfferInsurance);

            return list;
        }
    }
}