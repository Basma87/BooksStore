using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Formats
{
    public class DeleteModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DeleteModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Format Format { get; set; }

        public IActionResult OnGet(int? id)
        {


            Format = _context.Format.Where(c=> c.formatID.Equals(id)).FirstOrDefault();

            if (Format == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (Format is null)
            {
                return BadRequest();
            }

            else
            {
                _context.Format.Remove(Format);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
