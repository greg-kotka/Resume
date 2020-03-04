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
    [Route("api/[controller]")]
    public class EmployeeCompanyRelController : ControllerBase
    {
        private IEmployeeCompanyRelData employeeCompanyRelData;
        public IEnumerable<EmployeeCompanyRel> EmployeeCompanyRel { get; set; }

        public EmployeeCompanyRelController(IEmployeeCompanyRelData employeeCompanyRelData)
        {
            this.employeeCompanyRelData = employeeCompanyRelData;
        }

        // GET: api/EmployeeCompanyRel/5
        [HttpGet("{id}")]
        public IEnumerable<EmployeeCompanyRel> Get(int id)
        {
            EmployeeCompanyRel = employeeCompanyRelData.GetEmployeeCompanyRelsByUserID(id);
            return EmployeeCompanyRel.ToArray();
        }

        // POST: api/EmployeeCompanyRel
        [HttpPost]
        public void Post([FromBody] EmployeeCompanyRel updateEmployeeCompanyRel)
        {
            employeeCompanyRelData.Update(updateEmployeeCompanyRel);
        }

        // PUT: api/EmployeeCompanyRel/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeCompanyRel value)
        {
            employeeCompanyRelData.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}