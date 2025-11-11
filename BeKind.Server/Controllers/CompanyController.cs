using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockNewsTracker.Server.Dto;
using StockNewsTracker.Server.Response.Company;
using StockNewsTracker.Services.Intrerface;

namespace StockNewsTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }


        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var userCompanies = await _companyService.GetAllCompaniesNames();

            if (userCompanies == null)
            {
                return NotFound();
            }

            return Ok(userCompanies);
        }
    }
}
