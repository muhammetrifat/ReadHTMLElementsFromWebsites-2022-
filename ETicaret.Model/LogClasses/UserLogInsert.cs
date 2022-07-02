using ETicaret.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.LogClasses
{
    public class UserLogInsert
    {
        TrendyolDB db = new TrendyolDB();
        Int64 UserID;
        string Action;
        public UserLogInsert(Int64 userid, string action)
        {
            UserID = userid;
            Action = action;
            databaseinsert();
        }

        public void databaseinsert()
        {
            UserLog usrlg = new UserLog();
            usrlg.UserID = UserID;
            usrlg.Action = Action;
            usrlg.CreateDate = DateTime.Now;
            usrlg.CreateUserID = UserID;
            db.UserLogs.Add(usrlg);
            db.SaveChanges();
        }
    }
}
