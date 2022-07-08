using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Countries
{
    public class IndexModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public IndexModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public IList<Country> Country { get;set; }

        //public async Task OnGetAsync()
        //{
        //    Country = await _context.Country.ToListAsync();
        //}

        public void OnGet()
        {
            Country = _context.Country.ToList();
        }
    }
}
