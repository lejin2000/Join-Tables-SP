using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Join_Tables_SP.Models
{
    public class JoinTablesClass
    {
        public string author_name { get; set; }
        public string book_title { get; set; }
        public string publisher_name { get; set; }
    }
}
