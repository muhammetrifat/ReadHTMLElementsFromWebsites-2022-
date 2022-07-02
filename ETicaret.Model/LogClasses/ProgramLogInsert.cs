using ETicaret.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.LogClasses
{
    public class ProgramLogInsert
    {
        TrendyolDB db = new TrendyolDB();
        Int64 UserID;
        string message;
        public ProgramLogInsert(Int64 userid, string errormessage1)
        {
            UserID = userid;
            message = errormessage1;
            databaseinsert();
        }

        public void databaseinsert()
        {
            ProgramLog prlg = new ProgramLog();
            prlg.UserID = UserID;
            prlg.Message = message;
            prlg.CreateDate = DateTime.Now;
            prlg.CreateUserID = UserID;
            db.ProgramLogs.Add(prlg);
            db.SaveChanges();
        }
    }
}
