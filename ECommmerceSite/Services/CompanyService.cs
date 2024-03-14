using ECommmerceSite.Models;
using ECommmerceSite.Models.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;

namespace ECommmerceSite.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository) 
        {
            _companyRepository = companyRepository;
        }
        public bool Create(Company company)
        {
            bool createdCompany = _companyRepository.Create(company);
            return createdCompany;
        }

        public bool Delete(int companyId)
        {
           bool deletedCompany = _companyRepository.Delete(companyId);
            return deletedCompany;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var gottenCompanies = _companyRepository.GetAllCompanies();
            return gottenCompanies;
        }

        public Company GetCompanyByID(int companyId)
        {
            var companyById = _companyRepository.GetCompanyByID(companyId);
            return companyById;
        }

        public bool Update(Company company)
        {
           bool updatedCompany = _companyRepository.Update(company);
           return updatedCompany;
        }
    }
}
