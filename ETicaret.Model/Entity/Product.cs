using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class Product : EntityBase
    {
        public Int64 SubMenuID { get; set; }
        public Int64 DataID { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string ImgUrl { get; set; }

    }
}
