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
    public class JobDescriptionController : ControllerBase
    {
        private IJobDescriptionData jobDescriptionData;
        public IEnumerable<JobDescription> jobDescription { get; set; }

        public JobDescriptionController(IJobDescriptionData jobDescriptionData)
        {
            this.jobDescriptionData = jobDescriptionData;
        }
        //[HttpGet]
        //public JobDescription Get()
        //{
        //    jobDescription = jobDescriptionData.GetUserByID(1);
        //    return jobDescription;
        //}

        // GET: api/User/5
        [HttpGet("{id}")]
        public IEnumerable<JobDescription> Get(int id)
        {
            jobDescription = jobDescriptionData.GetJobDescriptionsByEmployeeCompanyRel(id);
            return jobDescription;
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] JobDescription updateUser)
        {
            jobDescriptionData.Update(updateUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] JobDescription value)
        {
            jobDescriptionData.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}