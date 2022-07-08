using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Format
    {
        [Key]
        public int formatID { get; set; }

        public string formatType { get; set; }
        public DateTime dateAdded { get; set; }

        // foreign Key
        public int BookID { get; set; }


    }
}

