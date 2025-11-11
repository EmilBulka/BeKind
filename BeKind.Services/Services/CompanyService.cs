using AutoMapper;
using BeKind.Infrastructure.Entities;
using Domain.Core;
using Domain.Core.Errors;
using Domain.Entities;
using StockNewsTracker.Infrastructure.Repositories.Interface;
using StockNewsTracker.Services.Intrerface;

namespace StockNewsTracker.Services.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> AddUserCompany(int userId, Company company)
        {
            var operationResult = new OperationResult(true);
            var companyDSO = _mapper.Map<CompanyDSO>(company);

            var companyFromDb = await _companyRepository.GetCompanyIfExists(company.Name);

            if (companyFromDb == null)
                operationResult += await _companyRepository.AddCompany(companyDSO);
            else
                companyDSO = companyFromDb;

            var userCompanyAlreadyExists = await _companyRepository.UserCompanyExists(companyDSO!.Id, userId);

            if (userCompanyAlreadyExists)
            {
                operationResult.IsValid = false;
                operationResult.Errors.Add(CompanyErrors.CompanyExists);
                return operationResult;
            }

            operationResult += await _companyRepository.AddUserCompany(userId, companyDSO);

            return operationResult;
        }

        public Task<ICollection<string>> GetAllCompaniesNames()
        {
            var companies = _companyRepository.GetAllCompaniesNames();
            return companies;
        }

        public async Task<ICollection<Company>> GetUserCompanies(int userId)
        {
            var companiesDSO = await _companyRepository.GetUserCompanies(userId);
            var companies = _mapper.Map<ICollection<Company>>(companiesDSO);
            return companies;
        }

        public Task<bool> UserCompanyExists(string companyName)
        {
            throw new NotImplementedException();
        }
    }
}
