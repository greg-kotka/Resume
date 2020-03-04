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
        public IEnumerable<Company> Company { get; set; }
       
        public CompanyController(ICompanyData companyData)
        {
            this.companyData = companyData;
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public IEnumerable<Company> Get(int id)
        {
            Company = companyData.GetCompaniesByUserId(id);
            return Company.ToArray();
        }

        // GET: api/Company/5
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            Company = companyData.GetCompanies();
            return Company.ToArray();
        }

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] Company updateCompany)
        {
            companyData.Update(updateCompany);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Company value)
        {
            companyData.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
