using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Model.Entity
{
    public class EntityBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ID { get; set; }
        public DateTime CreateDate { get; set; }
        public Int64 CreateUserID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Int64? UpdateUserID { get; set; }
    }
}
