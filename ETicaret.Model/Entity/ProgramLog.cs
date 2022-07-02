using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class ProgramLog : EntityBase
    {
        public Int64 UserID { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
    }
}
