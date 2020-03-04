using Microsoft.EntityFrameworkCore;
using Resume.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resume.data
{
    public class SqlPhoneData : IPhoneData
    {
        private readonly ResumeDbContext db;

        public SqlPhoneData(ResumeDbContext db)
        {
            this.db = db;
        }
        public Phone Add(Phone newPhone)
        {
            db.Add(newPhone);
            return newPhone;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Phone Delete(int ID)
        {
            var phone = GetPhoneByID(ID);
            if (phone != null)
            {
                db.Phone.Remove(phone);
            }
            return phone;
        }

        public Phone GetPhoneByID(int ID)
        {
            return db.Phone.Find(ID);
        }

        public Phone Update(Phone updatePhone)
        {
            var entity = db.Phone.Attach(updatePhone);
            entity.State = EntityState.Modified;
            return updatePhone;
        }
    }
}
