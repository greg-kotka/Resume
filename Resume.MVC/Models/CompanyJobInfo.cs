using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.MVC.Models
{
    public class CompanyJobInfo
    {
        public int EmployeeCompanyRel_ID { get; set; }

        public int Company_ID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Logo { get; set; }
        public string Link { get; set; }
    
        public int JobDescription_ID { get; set; }
        public string Title { get; set; }
        public string Job_Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
