using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Audiences
{
    public class IndexModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public IndexModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public IList<Audience> Audience { get;set; }

        public void  OnGet()
        {
            Audience = _context.Audience.ToList();
        }
    }
}
