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

namespace BooksStore.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public EditModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public IActionResult OnGet(int? id)
        {

            Category = _context.Category.Where(c=> c.CategoryID.Equals(id)).FirstOrDefault();

            if (Category is null)
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
            _context.Category.Update(Category);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.CategoryID == id);
        }
    }
}
