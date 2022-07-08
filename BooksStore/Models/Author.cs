using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string authorName { get; set; }
        public DateTime birthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime dateAdded { get; set; }

        //foreign Key
        public int CountryID { get; set; }


        // Navigation poperty
        public List<Book> bookList { get; set; }
    }
}
