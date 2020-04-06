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
        public List<Patent> patent { get; set; }
        public Phone phone { get; set; }

        public List<CompanyJobInfo> companyJobInfos { get; set; }


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
                string str = webClient.DownloadString(domain + "api/Usercompanies/" + UserID);
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
                JsonSerializerOptions JSO = new JsonSerializerOptions();
                JSO.PropertyNameCaseInsensitive = true;
                string str = webClient.DownloadString(domain + "api/Patent/" + UserID);
                patent = JsonSerializer.Deserialize<List<Patent>>(str, JSO);
            }

            using (WebClient webClient = new WebClient())
            {
                IEnumerable<JobDescription> thisjobDescriptions;
                foreach (EmployeeCompanyRel item in employeeCompanyRel)
                {
                    JsonSerializerOptions JSO = new JsonSerializerOptions();
                    JSO.PropertyNameCaseInsensitive = true;
                    string str = webClient.DownloadString(domain + "api/jobdescription/" + item.ID);
                    thisjobDescriptions = JsonSerializer.Deserialize<IEnumerable<JobDescription>>(str, JSO);
                    if (jobDescriptions != null)
                    {
                        jobDescriptions.AddRange(thisjobDescriptions);                       
                    }
                    else
                    {
                        jobDescriptions = thisjobDescriptions.ToList();
                    }

                }
            }
            companyJobInfos = new List<CompanyJobInfo>();
            CompanyJobInfo thisCJI;
            foreach (Company thisc in company)
            {
                thisCJI = new CompanyJobInfo();
                thisCJI.Company_ID = thisc.ID;
                thisCJI.CompanyName = thisc.CompanyName;
                thisCJI.Logo = thisc.Logo;
                thisCJI.Link = thisc.Link;
                thisCJI.City = thisc.City;
                thisCJI.EmployeeCompanyRel_ID = employeeCompanyRel.Where(ECR => ECR.Company_ID == thisc.ID && ECR.UserInfo_ID == userInfo.ID).Select(e => e.ID).FirstOrDefault();
                foreach (JobDescription thisJD in jobDescriptions.Where(jd => jd.EmployeeCompanyRel_ID == thisCJI.EmployeeCompanyRel_ID))
                {
                    thisCJI.JobDescription_ID = thisJD.ID;
                    thisCJI.Job_Description = thisJD.Job_Description;
                    thisCJI.Title = thisJD.Title;
                    thisCJI.StartDate = thisJD.StartDate;
                    thisCJI.EndDate = thisJD.EndDate;
                }
                companyJobInfos.Add(thisCJI);
            }                        
        }
    }
}
