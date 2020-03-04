using Microsoft.EntityFrameworkCore;
using System.Linq;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.data
{
    public class SqlPatentData : IPatentData
    {
        private readonly ResumeDbContext db;

        public SqlPatentData(ResumeDbContext db)
        {
            this.db = db;
        }
        public Patent Add(Patent newPatent)
        {
            db.Add(newPatent);
            return newPatent;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Patent Delete(int ID)
        {
            var employeeCompanyRel = GetByID(ID);
            if (employeeCompanyRel != null)
            {
                db.Patent.Remove(employeeCompanyRel);
            }
            return employeeCompanyRel;
        }

        public Patent GetByID(int ID)
        {
            return db.Patent.Find(ID);
        }

        public IEnumerable<Patent> GetPatentsByUserID(int User_ID)
        {
            var query = from c in db.Patent
                        where
                         c.UserInfo_ID == User_ID
                        orderby c.ID
                        select c;
            return query;
        }

        public Patent Update(Patent updatedPatent)
        {
            var entity = db.Patent.Attach(updatedPatent);
            entity.State = EntityState.Modified;
            return updatedPatent;
        }
    }
}
