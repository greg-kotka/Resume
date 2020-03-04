using System;
using System.Collections.Generic;
using System.Text;
using Resume.core;
namespace Resume.data
{
    public interface ICompanyData
    {
        IEnumerable<Company> GetCompanies();
        IEnumerable<Company> GetCompaniesByUserId(int UserID);
        Company GetCompanyByID(int ID);
        Company Update(Company updateCompany);
        Company Add(Company newCompany);
        Company Delete(int ID);
        int Commit();

    }
    public interface IJobDescriptionData
    {
        IEnumerable<JobDescription> GetJobDescriptionsByEmployeeCompanyRel(int EmployeeCompanyRel_ID);
        JobDescription GetByID(int ID);
        JobDescription Update(JobDescription updateJobDescription);
        JobDescription Add(JobDescription newJobDescription);
        JobDescription Delete(int ID);
        int Commit();

    }
    public interface IEmployeeCompanyRelData
    {
        IEnumerable<EmployeeCompanyRel> GetEmployeeCompanyRelsByUserID(int User_ID);
        IEnumerable<EmployeeCompanyRel> GetEmployeeCompanyRelsByCompanyID(int Company_ID);
        EmployeeCompanyRel GetByID(int ID);
        EmployeeCompanyRel Update(EmployeeCompanyRel updateEmployeeCompanyRel);
        EmployeeCompanyRel Add(EmployeeCompanyRel newEmployeeCompanyRel);
        EmployeeCompanyRel Delete(int ID);
        int Commit();
    }
    public interface IPhoneData
    {
        Phone GetPhoneByID(int ID);

        Phone Update(Phone updatePhone);
        Phone Add(Phone newPhone);
        Phone Delete(int ID);
        int Commit();
    }
    public interface IUserInfoData
    {
        IEnumerable<UserInfo> userInfosByName(string FirstName, string LastName);
        UserInfo GetUserByID(int ID);

        UserInfo Update(UserInfo updateUserInfo);
        UserInfo Add(UserInfo newUserInfo);
        UserInfo Delete(int ID);
        int Commit();
    }

    //public interface IResumeData
    //{

    //}
}
