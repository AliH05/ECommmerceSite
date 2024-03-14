using System.Collections;
using System.Collections.Generic;

namespace ECommmerceSite.Models.IRepositories
{
    public interface ICompanyRepository 
    {
        bool Create (Company company);

        bool Update (Company company);

        bool Delete (int companyId);

        Company GetCompanyByID (int companyId);

        IEnumerable<Company> GetAllCompanies ();
    }
}
