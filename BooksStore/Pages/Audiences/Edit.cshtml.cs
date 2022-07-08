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

namespace BooksStore.Pages.Audiences
{
    public class EditModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public EditModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Audience Audience { get; set; }


        public IActionResult OnGet(int id)
        {
            Audience = _context.Audience.Where(c => c.AudienceID.Equals(id)).FirstOrDefault();

            if (Audience is null)
            {
                return NotFound();
            }

            else
            {
                return Page();
            }


        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            else
            {
                _context.Audience.Update(Audience);
                _context.SaveChanges();

                return RedirectToPage("./Index");
            }
        }

        private bool AudienceExists(int id)
        {
            return _context.Audience.Any(e => e.AudienceID == id);
        }
    }
}
