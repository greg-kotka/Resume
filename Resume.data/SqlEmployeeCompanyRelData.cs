using Microsoft.EntityFrameworkCore;
using System.Linq;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.data
{
    public class SqlEmployeeCompanyRelData : IEmployeeCompanyRelData
    {
        private readonly ResumeDbContext db;

        public SqlEmployeeCompanyRelData(ResumeDbContext db)
        {
            this.db = db;
        }
        public EmployeeCompanyRel Add(EmployeeCompanyRel newEmployeeCompanyRel)
        {
            db.Add(newEmployeeCompanyRel);
            return newEmployeeCompanyRel;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public EmployeeCompanyRel Delete(int ID)
        {
            var employeeCompanyRel = GetByID(ID);
            if (employeeCompanyRel != null)
            {
                db.EmployeeCompanyRel.Remove(employeeCompanyRel);
            }
            return employeeCompanyRel;
        }

        public EmployeeCompanyRel GetByID(int ID)
        {
            return db.EmployeeCompanyRel.Find(ID);
        }

        public IEnumerable<EmployeeCompanyRel> GetEmployeeCompanyRelsByCompanyID(int Company_ID)
        {
            var query = from c in db.EmployeeCompanyRel
                        where
                         c.Company_ID == Company_ID
                        orderby c.ID
                        select c;
            return query;
        }

        public IEnumerable<EmployeeCompanyRel> GetEmployeeCompanyRelsByUserID(int User_ID)
        {
            var query = from c in db.EmployeeCompanyRel
                        where
                         c.UserInfo_ID == User_ID
                        orderby c.ID
                        select c;
            return query;
        }

        public EmployeeCompanyRel Update(EmployeeCompanyRel updatedEmployeeCompanyRel)
        {
            var entity = db.EmployeeCompanyRel.Attach(updatedEmployeeCompanyRel);
            entity.State = EntityState.Modified;
            return updatedEmployeeCompanyRel;
        }
    }
}
