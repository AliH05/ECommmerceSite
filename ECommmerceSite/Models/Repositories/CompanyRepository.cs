using ECommmerceSite.Data;
using ECommmerceSite.Models.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace ECommmerceSite.Models.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        public bool Create(Company company)
        {
            try
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Delete(int companyId)
        {
            try
            {
                Company company = GetCompanyByID(companyId);
                _context.Companies.Remove(company);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            var companies = _context.Companies.ToList();
            return companies;
        }

        public Company GetCompanyByID(int companyId)
        {
            Company company = _context.Companies.SingleOrDefault(x => x.ID == companyId);
            return company;
        }

        public bool Update(Company company)
        {
            try
            {
                _context.Companies.Update(company);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                return false;
            }
        }
    }
}
