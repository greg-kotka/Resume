using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.core
{
    public class JobDescription
    {     
        public int ID { get; set; }      
        public string Title { get; set; }
       public string Job_Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
