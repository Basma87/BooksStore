using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        [Required]
        public string countryName { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string keyCode { get; set; }
        [Required]
        public DateTime dateAdded { get; set; }
    }
}
