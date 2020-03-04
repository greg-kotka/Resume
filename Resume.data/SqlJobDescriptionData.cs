using Microsoft.EntityFrameworkCore;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resume.data
{
    public class SqlJobDescriptionData : IJobDescriptionData
    {
        private readonly ResumeDbContext db;
        public SqlJobDescriptionData(ResumeDbContext db)
        {
            this.db = db;
        }
        public JobDescription Add(JobDescription newJobDescription)
        {
            db.Add(newJobDescription);
            return newJobDescription;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public JobDescription Delete(int ID)
        {
            var jobDescription = GetByID(ID);
            if (jobDescription != null)
            {
                db.JobDescription.Remove(jobDescription);
            }
            return jobDescription;
        }

        public JobDescription GetByID(int ID)
        {
            return db.JobDescription.Find(ID);
        }

        public IEnumerable<JobDescription> GetJobDescriptionsByEmployeeCompanyRel(int EmployeeCompanyRel_ID)
        {
            var query = from c in db.JobDescription
                        where
                         c.EmployeeCompanyRel_ID == EmployeeCompanyRel_ID
                        orderby c.ID
                        select c;
            return query;
        }

        public JobDescription Update(JobDescription updateJobDescription)
        {
            var entity = db.JobDescription.Attach(updateJobDescription);
            entity.State = EntityState.Modified;
            return updateJobDescription;
        }
    }
}
