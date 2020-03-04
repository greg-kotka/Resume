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
    public class PatentController : ControllerBase
    {
        private IPatentData patentData;
        public IEnumerable<Patent> Patent { get; set; }

        public PatentController(IPatentData patentData)
        {
            this.patentData = patentData;
        }

        // GET: api/Patent/5
        [HttpGet("{id}")]
        public IEnumerable<Patent> Get(int id)
        {
            Patent = patentData.GetPatentsByUserID(id);
            return Patent.ToArray();
        }

        // POST: api/Patent
        [HttpPost]
        public void Post([FromBody] Patent updatePatent)
        {
            patentData.Update(updatePatent);
        }

        // PUT: api/Patent/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patent value)
        {
            patentData.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}