using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class Merchant : EntityBase
    {
        public string Name { get; set; }
        public Int64 FollowerCount { get; set; }
        public double Rating { get; set; }

    }
}
