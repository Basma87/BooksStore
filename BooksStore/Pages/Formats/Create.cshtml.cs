using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Formats
{
    public class CreateModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public CreateModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Format Format { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Format.Add(Format);
             _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
