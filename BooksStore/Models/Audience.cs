using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksStore.Models
{
    public class Audience
    {
        [Key]
        public int AudienceID { get; set; }
        public string audienceName { get; set; }

        public DateTime dateAdded { get; set; }

    }
}
