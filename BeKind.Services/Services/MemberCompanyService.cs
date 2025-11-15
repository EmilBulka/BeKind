using AutoMapper;
using BeKind.Infrastructure.Entities;
using Domain.Core;
using Domain.Core.Errors;
using Domain.Entities;
using StockNewsTracker.Infrastructure.Repositories;
using StockNewsTracker.Infrastructure.Repositories.Interface;
using StockNewsTracker.Services.Intrerface;

namespace StockNewsTracker.Services.Services
{
    public class MemberCompanyService : IMemberCompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMemberCompanyRepository _memberCompanyRepository;
        private readonly IMapper _mapper;

        public MemberCompanyService(ICompanyRepository companyRepository, IMemberCompanyRepository memberCompanyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _memberCompanyRepository = memberCompanyRepository;
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

            var userCompanyAlreadyExists = await _memberCompanyRepository.UserCompanyExists(companyDSO!.Id, userId);

            if (userCompanyAlreadyExists)
            {
                operationResult.IsValid = false;
                operationResult.Errors.Add(CompanyErrors.CompanyExists);
                return operationResult;
            }

            operationResult += await _memberCompanyRepository.AddUserCompany(userId, companyDSO);

            return operationResult;
        }
            public async Task<OperationResult> DeleteUserCompanies(int userId, ICollection<string> companies)
            {
                var result = new OperationResult();

                result += await _memberCompanyRepository.DeleteUserCompanies(userId, companies);

                return result;       
            }
       
        public Task<ICollection<string>> GetAllCompaniesNames()
        {
            var companies = _companyRepository.GetAllCompaniesNames();
            return companies;
        }

        public async Task<ICollection<Company>> GetUserCompanies(int userId)
        {
            var companiesDSO = await _memberCompanyRepository.GetUserCompanies(userId);
            var companies = _mapper.Map<ICollection<Company>>(companiesDSO);
            return companies;
        }

        
    }
}
