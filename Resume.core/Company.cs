using System;
using System.ComponentModel.DataAnnotations;

namespace Resume.core
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string State { get; set; }
        public string Logo { get; set; }
        [MaxLength(300)]
        public string Link { get; set; }
    }
}
