using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;

namespace BooksStore.Models
{
    public class EditModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public EditModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AudienceID"] = new SelectList(_context.Set<Audience>(), "AudienceID", "AudienceID");
           ViewData["AuthorID"] = new SelectList(_context.Set<Author>(), "AuthorID", "AuthorID");
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "CategoryID", "CategoryID");
           ViewData["CountryID"] = new SelectList(_context.Set<Country>(), "CountryID", "CountryID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.BookID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.BookID == id);
        }
    }
}
