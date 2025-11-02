using StockNewsTracker.Server.Dto;

namespace StockNewsTracker.Server.Response.Company
{
    public class GetUserCompaniesResponse
    {
        public string UserName { get; set; }
        public List<CompanyDTO> Companies { get; set; }
    }
}
