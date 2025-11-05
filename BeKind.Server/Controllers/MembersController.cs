using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockNewsTracker.Server.Dto;
using StockNewsTracker.Server.Response.Company;
using StockNewsTracker.Services.Intrerface;
using StockNewsTracker.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StockNewsTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public MembersController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet("Member/{userId:int}/Companies")]
        public async Task<IActionResult> Get(int userId)
        {
            var userCompanies = await _companyService.GetUserCompanies(userId);

            if (userCompanies == null) 
                return NotFound("Companies Not Found");

            var userCompaniesDTO = _mapper.Map<List<CompanyDTO>>(userCompanies);

            var response = new GetUserCompaniesResponse()
            {
                UserName = "Bulczo", //temp
                Companies = userCompaniesDTO
            };
            
            return Ok(response);
        }

    }
}
