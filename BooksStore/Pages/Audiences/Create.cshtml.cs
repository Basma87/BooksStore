using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Audiences
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
        public Audience Audience { get; set; }


        public IActionResult OnPost()
        {
            _context.Audience.Add(Audience);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }

      
    }
}
