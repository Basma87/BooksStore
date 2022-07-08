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
    public class DeleteModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DeleteModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Audience Audience { get; set; }

        public IActionResult OnGet(int? id)
        {
            
            Audience = _context.Audience.Where(m => m.AudienceID .Equals( id)).FirstOrDefault();

            if (Audience == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            _context.Audience.Remove(Audience);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
     
    }
}
