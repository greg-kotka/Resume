using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resume.core;
using Resume.data;
namespace Resume.API.Controllers
{
    [ApiController]
    [Route("api/Company")]
    public class CompanyController : ControllerBase
    {

        private ICompanyData companyData;
        public IEnumerable<Company> Companies { get; set; }
        public Company company { get; set; }
       
        public CompanyController(ICompanyData companyData)
        {
            this.companyData = companyData;
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public Company Get(int id)
        {
            company = companyData.GetCompanyByID(id);
            return company;
        }

        // GET: api/Company/5
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            Companies = companyData.GetCompanies();
            return Companies.ToArray();
        }

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] Company addCompany)
        {
            companyData.Add(addCompany);
            companyData.Commit();
            int id = addCompany.ID;
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company value)
        {
            companyData.Update(value);
            companyData.Commit();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            companyData.Delete(id);
            companyData.Commit();
        }
    }
}
