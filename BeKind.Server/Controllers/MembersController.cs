using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using StockNewsTracker.Server.Dto;
using StockNewsTracker.Server.Model.Response.Company;
using StockNewsTracker.Services.Intrerface;


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
                UserName = "Bulczo", 
                Companies = userCompaniesDTO
            };
            
            return Ok(response);
        }

        [HttpPost("Member/{userId:int}/Companies/{companyName}")]
        public async Task<IActionResult> Add(string companyName, int userId)
        {
            var company = new Company(companyName, true);
            var addCompanyResult = await _companyService.AddUserCompany(userId, company);

            if (addCompanyResult.IsValid == false)
            {
                return BadRequest(addCompanyResult.Errors);
            }

            return Ok();
        }

    }
}
