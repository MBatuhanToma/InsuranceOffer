using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teklif.Services.Models;

namespace Teklif.Services.Abstract
{
    public interface IBidCalculation
    {
       Task<BidCalculationOutPut> BidCalculation(BidCalculationInPut data, string company);
    }
}
