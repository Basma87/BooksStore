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
    public class DetailsModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DetailsModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public Country Country { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Country = await _context.Country.FirstOrDefaultAsync(m => m.CountryID == id);

            if (Country == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
