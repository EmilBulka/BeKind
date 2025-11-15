using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockNewsTracker.Services.Intrerface;

namespace StockNewsTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMemberCompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(IMemberCompanyService companyService, IMapper mapper)
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
