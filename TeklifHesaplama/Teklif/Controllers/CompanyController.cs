using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Teklif.Services.Abstract;
using Teklif.Services.Models;

namespace Teklif.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IBidCalculation _service;

        private readonly ILogger<CompanyController> _logger;

        public CompanyController(IBidCalculation service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<BidCalculationOutPut> GetCompanyA(BidCalculationInPut data)
        {
            return await _service.BidCalculation(data, "A");
        }

        [HttpGet]
        public async Task<BidCalculationOutPut> GetCompanyB(BidCalculationInPut data)
        {
            return await _service.BidCalculation(data, "B");
        }

        [HttpGet]
        public async Task<BidCalculationOutPut> GetCompanyC(BidCalculationInPut data)
        {
            return await _service.BidCalculation(data, "C");
        }
    }
}
