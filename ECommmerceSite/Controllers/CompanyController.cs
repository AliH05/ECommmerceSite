using ECommmerceSite.Models;
using ECommmerceSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommmerceSite.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        public IActionResult Index() 
        {
            var companies = _companyService.GetAllCompanies();
            return View(companies);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Company company)
        {
            var createdCompany = _companyService.Create(company);
            if(createdCompany)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Update(int companyId)
        {
            var company = _companyService.GetCompanyByID(companyId);
            return View(company);
        }

        [HttpPost]
        public IActionResult Update(Company company)
        {
            var createdCompany = _companyService.Update(company);
            if (createdCompany)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int companyId) 
        {
            var deletedCompany = _companyService.Delete(companyId);
            return RedirectToAction("Index");
        }


    }
}
