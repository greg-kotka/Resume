using Microsoft.EntityFrameworkCore;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.data
{
    public class ResumeDbContext : DbContext
    {
        public ResumeDbContext(DbContextOptions<ResumeDbContext> options)
            : base(options)
        { }
        public DbSet<Company> Company { get; set; }
        public DbSet<JobDescription> JobDescription { get; set; }
        public DbSet<EmployeeCompanyRel> EmployeeCompanyRel { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
