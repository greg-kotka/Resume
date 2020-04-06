using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.core
{
   public class EmployeeCompanyRel
    {
        public int ID { get; set; }
        public int UserInfo_ID { get; set; }
        public int Company_ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
