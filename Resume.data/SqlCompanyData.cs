using Microsoft.EntityFrameworkCore;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resume.data
{
    public class SqlCompanyData : ICompanyData
    {
        private readonly ResumeDbContext db;

        public SqlCompanyData(ResumeDbContext db)
        {
            this.db = db;
        }

        public Company Add(Company newCompany)
        {
            db.Add(newCompany);
            return newCompany;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Company Delete(int id)
        {
            var company = GetCompanyByID(id);
            if (company != null)
            {
                db.Company.Remove(company);
            }
            return company;
        }

        public IEnumerable<Company> GetCompaniesByUserID(int UserID)
        {
            var listOfIDs = (from ecr in db.EmployeeCompanyRel where ecr.UserInfo_ID == UserID select ecr.Company_ID);
            var query = from c in db.Company
                        where listOfIDs.Contains(c.ID)
                        orderby c.CompanyName
                        select c;
            return query;
        }

        public IEnumerable<Company> GetCompanies()
        {
            var query = from c in db.Company
                        orderby c.CompanyName
                        select c;
            return query;
        }

        public Company GetCompanyByID(int ID)
        {
            return db.Company.Find(ID);
        }

        public Company Update(Company updatedCompany)
        {
            var entity = db.Company.Attach(updatedCompany);
            entity.State = EntityState.Modified;
            return updatedCompany;
        }
    }


}

