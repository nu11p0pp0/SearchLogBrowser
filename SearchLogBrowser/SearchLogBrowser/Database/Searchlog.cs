using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLogBrowser.Database
{
    [Table("searchlog")]
    public class Searchlog
    {
        [Column("logno"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Logno { get; set;}
        [Column("username")]
        public String Username { get; set; }
        [Column("searchdate")]
        public DateTime Searchdate { get; set; }
        [Column("searchtext")]
        public String Searchtext { get; set; }
        [Column("resolved")]
        public int Resolved { get; set; }
        [Column("url")]
        public String Url { get; set; }
        [Column("memo")]
        public String Memo { get; set; }
    }
}
