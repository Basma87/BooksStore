using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Categories
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
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Category.Add(Category);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}

        public IActionResult OnPost(Category category)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Category.Add(category);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }

  
}
