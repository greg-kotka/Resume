using System;

namespace Resume.core
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Int32 Logo { get; set; }
    }
}
