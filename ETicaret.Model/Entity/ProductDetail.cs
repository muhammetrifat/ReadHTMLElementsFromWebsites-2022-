using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class ProductDetail : EntityBase
    {
        public Int64 ProductID { get; set; }
        public Int64 MerchantID { get; set; }
        public Merchant Merchant { get; set; }
        public double Price { get; set; }
        public double StarCount { get; set; }
        public Int64 ReviewCount { get; set; }
        public int QACount { get; set; }
        public int FavouriteCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime EstShipTime { get; set; }
        public int LastStock { get; set; }
        public string OtherDetails { get; set; }

    }
}
