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
    public class IndexModel : PageModel
    {
        private readonly BooksStoreContext _context;

        public IndexModel(BooksStoreContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public IActionResult OnGet()
        {
            Book =  _context.Book
                .Include(b => b.audience)
                .Include(b => b.author)
                .Include(b => b.category)
                .Include(b => b.country).ToList();


            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(Book book)
        //{
        //    _context.Book.Add(book);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
