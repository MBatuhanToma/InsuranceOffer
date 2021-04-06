using Insurance.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Insurance.Controllers
{
    public class BidsReceivedController : Controller
    {
        InsuranceContext db = new InsuranceContext();

        public IActionResult Index()
        {
            return View(db.OfferInsurance.ToList());
        }
    }
}
