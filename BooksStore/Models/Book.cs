using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public int numberOfPages { get; set; }
        public int price { get; set; }
        public string bookCover { get; set; }
        public string ISBN { get; set; }
        public int numberOfCopies { get; set; }
        public string Description { get; set; }
        public string language { get; set; }
        public string Dimensions { get; set; }
        public string weight { get; set; }
        public DateTime dateAdded { get; set; }

        public int AuthorID { get; set; }  // foreign key
        public int CountryID { get; set; } // foreign key
        public int AudienceID { get; set; } // foreign key
        public int CategoryID { get; set; } // foreign key

        // navigation properities
        public Author author { get; set; }
        public Country country { get; set; }
        public Audience audience { get; set; }
        public Category category { get; set; }

        public List<Format> formats { get; set; }


    }
}
