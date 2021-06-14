using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace Authenticator.Areas.Identity.Data
{
    public class UserInfo : IdentityUser
    {
        [PersonalData]
        public string FName { get; set; }
        [PersonalData]
        public string LName { get; set; }
    }
}
