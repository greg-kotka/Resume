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
    [Route("api/User")]
    public class UserController : ControllerBase
    {


        private IUserInfoData userData;
        public UserInfo userInfo { get; set; }

        public UserController(IUserInfoData userData)
        {
            this.userData = userData;
        }
        //[HttpGet]
        //public UserInfo Get()
        //{
        //    userInfo = userData.GetUserByID(1);
        //    return userInfo;
        //}

        // GET: api/User/5
        [HttpGet("{id}")]
        public UserInfo Get(int id)
        {
            userInfo = userData.GetUserByID(id);
            return userInfo;
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] UserInfo updateUser)
        {
            userData.Update(updateUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserInfo value)
        {
            userData.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}