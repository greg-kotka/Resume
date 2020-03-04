using Microsoft.EntityFrameworkCore;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.data
{
    public class SqlUserInfoData : IUserInfoData
    {
        private readonly ResumeDbContext db;

        public SqlUserInfoData(ResumeDbContext db)
        {
            this.db = db;
        }
        public UserInfo Add(UserInfo newUserInfo)
        {
            db.Add(newUserInfo);
            return newUserInfo;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public UserInfo Delete(int ID)
        {
            var userInfo = GetUserByID(ID);
            if (userInfo != null)
            {
                db.UserInfo.Remove(userInfo);
            }
            return userInfo;
        }

        public UserInfo GetUserByID(int ID)
        {
            return db.UserInfo.Find(ID);
        }

        public UserInfo Update(UserInfo updateUserInfo)
        {
            var entity = db.UserInfo.Attach(updateUserInfo);
            entity.State = EntityState.Modified;
            return updateUserInfo;
        }

        public IEnumerable<UserInfo> userInfosByName(string FirstName, string LastName)
        {
            throw new NotImplementedException();
        }
    }
}
