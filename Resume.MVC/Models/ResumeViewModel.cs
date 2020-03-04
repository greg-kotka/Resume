using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using Resume.core;
namespace Resume.MVC.Models
{
    public class ResumeViewModel
    {
        public UserInfo userInfo { get; set; }
        public List<Company> company { get; set; }
        public List<JobDescription> jobDescriptions { get; set; }
        public List<EmployeeCompanyRel> employeeCompanyRel { get; set; }
        public Phone phone { get; set; }




        public ResumeViewModel(string domain, int? UserID)
        {

            if (UserID == null) { UserID = 1; }

            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/user/" + UserID);
                userInfo = JsonSerializer.Deserialize<UserInfo>(str, JSO);
            }


            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/company/" + UserID);
                company = JsonSerializer.Deserialize<List<Company>>(str, JSO);
            }

            using (WebClient webClient = new WebClient())
            {
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/EmployeeCompanyRel/" + UserID);
                employeeCompanyRel = JsonSerializer.Deserialize<List<EmployeeCompanyRel>>(str, JSO);
            }



            using (WebClient webClient = new WebClient())
            {
                IEnumerable<JobDescription> thisjobDescriptions;
                foreach (EmployeeCompanyRel item in employeeCompanyRel)
                {
                    JsonSerializerOptions JSO = new JsonSerializerOptions();
                    JSO.PropertyNameCaseInsensitive = true;
                    string str = webClient.DownloadString(domain + "api/jobdescription/" + item.Id);
                    thisjobDescriptions = JsonSerializer.Deserialize<IEnumerable<JobDescription>>(str, JSO);
                    if (jobDescriptions != null)
                    {
                        jobDescriptions.AddRange(thisjobDescriptions);
                        //foreach (JobDescription jd in thisjobDescriptions)
                        //{
                        //    jobDescriptions.Append(jd);
                        //}
                    }
                    else
                    {
                        jobDescriptions = thisjobDescriptions.ToList();
                    }

                }
            }

        }
    }
}
