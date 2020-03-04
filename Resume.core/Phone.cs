using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.core
{
    public class Phone
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
        public string OtherDesc { get; set; }
    }
}
