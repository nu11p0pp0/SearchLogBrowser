using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchLogBrowser.Database
{
    [Table("searchword")]
    public class Searchword
    {
        [Column("id")]
        public String Id { get; set; }
        [Column("search_timestamp")]
        public DateTime SearchTimestamp { get; set; }
        [Column("search_word")]
        public String SearchWord { get; set; }
        [Column("url")]
        public String Url { get; set; }
        [Column("answer")]
        public String Answer { get; set; }
        [Column("endflg")]
        public Boolean Endflg { get; set; }
    }
}
