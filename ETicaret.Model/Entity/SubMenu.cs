using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class SubMenu : EntityBase
    {
        public Int64 MenuHeaderID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

    }
}
