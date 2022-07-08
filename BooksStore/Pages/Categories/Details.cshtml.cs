using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BooksStore.Data;
using BooksStore.Models;

namespace BooksStore.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly BooksStore.Data.BooksStoreContext _context;

        public DetailsModel(BooksStore.Data.BooksStoreContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public IActionResult OnGet(int id)
        {

            Category = _context.Category.Where(c => c.CategoryID.Equals(id)).FirstOrDefault();

            if (Category is null)
            {
                return NotFound();
            }

            else
            {
                return Page();
            }
        }

      

    }
}
