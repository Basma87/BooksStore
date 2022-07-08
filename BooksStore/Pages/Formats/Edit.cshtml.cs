using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Formats
{
    public class EditModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public EditModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Format Format { get; set; }


        public IActionResult OnGet(int ?id)
        {
            Format = _context.Format.FirstOrDefault(c=>c.formatID==id);

            if (Format is null)
            {
                return NotFound();
            }

            else
            {
                return Page();
            }
          
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (Format is null)
            {
                return BadRequest();
            }

            else
            {
                _context.Format.Update(Format);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }

        private bool FormatExists(int id)
        {
            return _context.Format.Any(e => e.formatID == id);
        }
    }
}
