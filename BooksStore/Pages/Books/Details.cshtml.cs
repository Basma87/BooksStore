using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;

namespace BooksStore.Models
{
    public class DetailsModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DetailsModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.audience)
                .Include(b => b.author)
                .Include(b => b.category)
                .Include(b => b.country).FirstOrDefaultAsync(m => m.BookID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
