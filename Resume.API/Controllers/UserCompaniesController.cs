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
    [Route("api/[controller]")]
    [ApiController]
    public class UserCompaniesController : ControllerBase
    {
        private ICompanyData companyData;
        public IEnumerable<Company> Company { get; set; }

        public UserCompaniesController(ICompanyData companyData)
        {
            this.companyData = companyData;
        }
        // GET: api/Company/5
        [HttpGet("{id}")]
        public IEnumerable<Company> Get(int id)
        {           
            Company = companyData.GetCompaniesByUserID(id);
            return Company.ToArray();
        }
    }
}