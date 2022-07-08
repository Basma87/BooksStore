using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksStore.Models;

namespace BooksStore.Data
{
    public class BooksStoreContext : DbContext
    {
        public BooksStoreContext (DbContextOptions<BooksStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<BooksStore.Models.Country> Country { get; set; }

        public DbSet<BooksStore.Models.Audience> Audience { get; set; }

        public DbSet<BooksStore.Models.Format> Format { get; set; }

        public DbSet<BooksStore.Models.Category> Category { get; set; }

    
    }
}
